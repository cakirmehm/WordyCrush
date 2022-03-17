using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordyCrush
{
    public partial class F_WordCrush : Form
    {
        private const int GRID_MAX = 8;
        private int TotalScore = 0;
        HashSet<string> HsDrawnWords = new HashSet<string>();
        HashSet<ucCell> selectedTagList = new HashSet<ucCell>();
        HashSet<string> WordsDB = new HashSet<string>();
        HashSet<int> HsFoundIndexList = new HashSet<int>();
        Dictionary<char, HashSet<string>> DctCharVsWordList = new Dictionary<char, HashSet<string>>();
        Dictionary<ucWordRow, HashSet<ucCell>> DctCellvsTagList = new Dictionary<ucWordRow, HashSet<ucCell>>();
        char[,] board = new char[GRID_MAX, GRID_MAX];
        private ucCell lastTag = null;
        public EGameMode GameMode { get; set; } = EGameMode.FLOATING;
        public ELanguage Lang { get; set; } = ELanguage.TR;

        private string TR_ALPHABET_UPPER = "AAAABCÇDEEEEFGĞHIIİİİJKKLMMNOOÖPRSŞTUUÜVYZ";
        private string TR_ALPHABET_LOWER = "abcçdefgğhıijklmnoöprsştuüvyz";

        private string ENG_ALPHABET_UPPER = "AAAABCCDEEEEFGGHIIJKKLMMNOOOPQRSTUUUVYZ";
        private string ENG_ALPHABET_LOWER = "abcdefghijklmnopqrstuvwxyz";

        private string SP_ALPHABET_LOWER = "abcdefghijklmnñopqrstuvwxyz";



        Dictionary<char, char> DctTurkishChUpperToLower = new Dictionary<char, char>()
        {
            {'C','c'},
            {'Ç','ç'},
            {'G','g'},
            {'Ğ','ğ'},
            {'I','ı'},
            {'İ','i'},
            {'Ş','ş'},
            {'Ö','ö'},
            {'Ü','ü'},
        };

        List<CMove> Moves = new List<CMove>()
        {
            new CMove(){Row = 1, Col = 0},
            new CMove(){Row = 1, Col = 1},
            new CMove(){Row = 1, Col =-1},
            new CMove(){Row = 0, Col = 1},
            new CMove(){Row = 0, Col =-1},
            new CMove(){Row =-1, Col = 0},
            new CMove(){Row =-1, Col = 1},
            new CMove(){Row =-1, Col =-1},
        };

        public F_WordCrush(EGameMode gameMode, ELanguage lang)
        {
            InitializeComponent();

            Lang = lang;
            GameMode = gameMode;

            if (Lang == ELanguage.TR)
                loadWordsDB_TR();
            else if (Lang == ELanguage.EN)
                loadWordsDB_ENG();

            InitializePanels();
 
        }


        private void InitializePanels()
        {
            var chars = Lang == ELanguage.TR
            ? TR_ALPHABET_UPPER
            : ENG_ALPHABET_UPPER;

            var random = new Random(DateTime.Today.Year * DateTime.Today.Month);

            int pnlCounter = 0;
            foreach (var pnl in flowLayoutPanelMain.Controls)
            {
                FlowLayoutPanel flwPnl = pnl as FlowLayoutPanel;

                for (int i = 0; i < GRID_MAX; i++)
                {
                    ucCell cell = new ucCell();
                    cell.BorderStyle = BorderStyle.FixedSingle;

                    cell.GetLabel().AllowDrop = true;


                    cell.GetLabel().MouseEnter += lbl_MouseEnter;
                    cell.GetLabel().MouseDown += lbl_MouseDown;
                    cell.GetLabel().MouseLeave += lbl_MouseLeave;
                    cell.GetLabel().MouseUp += lbl_MouseUp;
                    cell.GetLabel().DragDrop += lbl_DragDrop;
                    cell.GetLabel().DragEnter += lbl_DragEnter;
                    cell.GetLabel().DragOver += lbl_DragOver;

                    cell.SetValue(chars[random.Next(chars.Length)]);
                    flwPnl.Controls.Add(cell);
                }

                pnlCounter++;
            }
        }




        private async void FrmExpo_VisibleChanged(object sender, EventArgs e)
        {
            Form frmSender = sender as Form;
            if (frmSender.Visible)
            {
                await Task.Run(() =>
                {
                    frmSender.Invoke(new MethodInvoker(delegate ()
                    {
                        
                        while (frmSender.Opacity > 0)
                        {
                            frmSender.Opacity--;
                            System.Threading.Thread.Sleep(100);
                        }
                        //frmSender.Hide();
                    }));

                   
                });
            }
           
        }

        private void Cell_Click(object sender, EventArgs e)
        {

        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void loadWordsDB_TR()
        {
            WordsDB = new HashSet<string>(File.ReadAllText("word.db\\tr.txt", Encoding.GetEncoding("iso-8859-9")).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (var c in TR_ALPHABET_LOWER.ToCharArray())
            {
                List<string> wordsToTest = WordsDB
                .Where(w => w[0] == c)
                //.OrderByDescending(w => w.Length)
                .ToList();

                DctCharVsWordList.Add(c, new HashSet<string>(wordsToTest));
            }
        }

        private void loadWordsDB_ENG()
        {
            WordsDB = new HashSet<string>(File.ReadAllText("word.db\\en.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (var c in ENG_ALPHABET_LOWER.ToCharArray())
            {
                List<string> wordsToTest = WordsDB
                .Where(w => w[0] == c)
                //.OrderByDescending(w => w.Length)
                .ToList();

                DctCharVsWordList.Add(c, new HashSet<string>(wordsToTest));
            }
        }

        private void clearStyles()
        {
            foreach (var pnl in flowLayoutPanelMain.Controls)
            {
                FlowLayoutPanel flwPnl = pnl as FlowLayoutPanel;

                foreach (var cnt in flwPnl.Controls)
                {
                    (cnt as ucCell).GetLabel().BackColor = Color.White;
                }
            }
        }

        private bool CheckDrawnWord(ucCell newTag)
        {
            if (selectedTagList.Count == 0 || lastTag == null) return true;


            int r1 = lastTag.GetCellIndex();
            int c1 = lastTag.GetParentIndex();

            int r2 = newTag.GetCellIndex();
            int c2 = newTag.GetParentIndex();

            int diff = Math.Max(Math.Abs(r1 - r2), Math.Abs(c1 - c2));

            return diff == 1;
        }


        private void paintPath(HashSet<ucCell> list)
        {
            ucCell lastTag = null;
            foreach (var cell in list)
            {
                ucCell newTag = cell;

                cell.GetLabel().BackColor = Color.Orange;

                if (lastTag != null)
                    assignDirection(cell, lastTag, newTag);

                lastTag = cell;
            }
        }

        private string wordConvert(string word)
        {

            StringBuilder sbRet = new StringBuilder();
            foreach (var c in word)
            {
                if (Lang == ELanguage.TR)
                {
                    if (DctTurkishChUpperToLower.ContainsKey(c))
                        sbRet.Append(DctTurkishChUpperToLower[c]);
                    else
                        sbRet.Append(c.ToString().ToLower());
                }
                else
                {
                    sbRet.Append(c.ToString().ToLowerInvariant());
                }
            }

            return sbRet.ToString();
        }

        private char charConvert(char ch)
        {
            if (Lang == ELanguage.TR)
            {
                if (DctTurkishChUpperToLower.ContainsKey(ch))
                    return DctTurkishChUpperToLower[ch];
                else
                    return ch.ToString().ToLower().First();
            }
            return ch.ToString().ToLowerInvariant().First();
        }

        private bool findWord(char[,] board, int r, int c, string inputKey, string outputKey)
        {
            if (inputKey.Length == 0)
                return true;

            char chToFind = inputKey.First();


            foreach (var move in Moves)
            {
                int rNew = r + move.Row;
                int cNew = c + move.Col;

                if (IsSafe(board, rNew, cNew, chToFind))
                {
                    inputKey = inputKey.Remove(0, 1);
                    outputKey = $"{outputKey}{chToFind}";
                    char[,] boardCopy = (char[,])board.Clone();

                    boardCopy[r, c] = '.';
                    boardCopy[rNew, cNew] = '.';

                    HsFoundIndexList.Add(rNew * GRID_MAX + cNew);

                    if (findWord(boardCopy, rNew, cNew, inputKey, outputKey))
                    {
                        return true;
                    }
                    else
                    {
                        inputKey = $"{chToFind}{inputKey}";
                        outputKey = outputKey.Remove(0, 1);

                        boardCopy[rNew, cNew] = chToFind;
                    }

                }
            }

            return false;

        }

        private bool IsSafe(char[,] board, int row, int col, char c)
        {
            if (row < 0 || col < 0 || row >= GRID_MAX || col >= GRID_MAX || charConvert(board[row, col]) != c)
                return false;
            return true;
        }



        // UI EVENTS --------------------------------

        private void lbl_DragOver(object sender, DragEventArgs e)
        {


            Label lbl = sender as Label;
            lbl.BackColor = Color.LightGreen;


            ucCell parentCell = lbl.Parent as ucCell;
            ucCell newTag = parentCell;

            // assign direction
            if (lastTag != null)
                assignDirection(parentCell, lastTag, newTag);


            if (selectedTagList.Add(parentCell))
            {
                lblDrawnWord.Text = string.Join(" ", selectedTagList.Select(u => u.GetLabel().Text));

                if (CheckDrawnWord(newTag))
                {
                    lblDrawnWord.ForeColor = Color.Green;
                }
                else
                {
                    lblDrawnWord.ForeColor = Color.Red;


                    clearStyles();
                    clearAllArrows();
                    selectedTagList.Clear();
                    lblDrawnWord.Text = "";
                    lastTag = null;
                }

                lastTag = newTag;
            }
        }

        private void clearArrows()
        {
            foreach (var item in selectedTagList)
            {
                item.HideAllLabels();
            }
        }

        private void clearAllArrows()
        {
            foreach (var cnt in flowLayoutPanelMain.Controls)
            {
                if (cnt is FlowLayoutPanel)
                {

                    FlowLayoutPanel flwPnl = cnt as FlowLayoutPanel;

                    foreach (var cell in flwPnl.Controls)
                    {
                        (cell as ucCell).HideAllLabels();
                    }
                }
            }

        }

        private void assignDirection(ucCell parentCell, ucCell lastTag, ucCell newTag)
        {
            int r1 = lastTag.GetCellIndex();
            int c1 = lastTag.GetParentIndex();

            int r2 = newTag.GetCellIndex();
            int c2 = newTag.GetParentIndex();

            parentCell.HideAllLabels();
            if (r1 == r2)
            {
                // right
                if (c1 < c2)
                {
                    lastTag.GetRightLabel().Visible = true;
                }

                // left
                if (c1 > c2)
                {
                    lastTag.GetLeftLabel().Visible = true;
                }
            }
            else if (c1 == c2)
            {
                // up
                if (r1 < r2)
                {
                    lastTag.GetUpLabel().Visible = true;
                }

                // down
                if (r1 > r2)
                {
                    lastTag.GetDownLabel().Visible = true;
                }
            }
            else
            {
                // right up
                if (c1 < c2 && r1 < r2)
                    lastTag.GetRightUpLabel().Visible = true;



                // right down
                else if (c1 < c2 && r1 > r2)
                    lastTag.GetRightDownLabel().Visible = true;

                // left down
                else if (c1 > c2 && r1 > r2)
                    lastTag.GetLeftDownLabel().Visible = true;

                // left up
                if (c1 > c2 && r1 < r2)
                    lastTag.GetLeftUpLabel().Visible = true;
            }
        }

        private void lbl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;

            }

        }

        private void lbl_DragDrop(object sender, DragEventArgs e)
        {
            Label lbl = sender as Label;
            //DoDragDrop(lbl.Text, DragDropEffects.All);

            if (lblDrawnWord.ForeColor == Color.Green)
            {
                string word = lblDrawnWord.Text.Replace(" ", "");
                string wordInDB = wordConvert(word);

                if (word.Length >= 2 && WordsDB.Contains(wordInDB))
                {
                    if (GameMode == EGameMode.STATIC && HsDrawnWords.Contains(word))
                    {

                        clearStyles();
                        clearAllArrows();
                        selectedTagList.Clear();
                        lblDrawnWord.Text = "";
                        lastTag = null;
                        return;
                    }
                    HsDrawnWords.Add(word);


                    int cnt = flowLayoutPanelScores.Controls.Count;
                    ucWordRow wr = new ucWordRow()
                    {
                        Score = word.Length * word.Length * word.Length + cnt,
                        Word = word
                    };


                    if (GameMode == EGameMode.STATIC)
                    {
                        if (DctCellvsTagList.ContainsKey(wr) == false)
                            DctCellvsTagList.Add(wr, new HashSet<ucCell>(selectedTagList));
                    }


                    wr.GetLabel().Click += (sender2, e2) =>
                    {
                        Label senderLbl = (sender2 as Label);
                        ucWordRow wordRow = senderLbl.Parent as ucWordRow;
                        clearStyles();
                        clearAllArrows();

                        if (DctCellvsTagList.ContainsKey(wordRow))
                        {
                            paintPath(DctCellvsTagList[wordRow]);
                        }

                    };

                    wr.updateUI(cnt);


                    flowLayoutPanelScores.Controls.Add(wr);
                    flowLayoutPanelScores.ScrollControlIntoView(wr);

                    TotalScore += wr.Score;
                    lblTotalScore.Text = TotalScore.ToString().PadLeft(3, '0');



                    if (GameMode == EGameMode.FLOATING)
                    {
                        foreach (ucCell cell in selectedTagList)
                        {
                            removeCell(cell);
                        }
                    }


                    CControlFlusher.highlightControl(flowLayoutPanelScores, Color.CadetBlue, Color.White);

                    if (false == IsSolvable())
                    {
                        if (true == IsBoardEmpty())
                            TotalScore += 10000;

                        MessageBox.Show($"Game over. Your score: {TotalScore}");
                  
                        flowLayoutPanelMain.Enabled = false;
                        return;
                    }

                   
                }

            }


            clearStyles();
            clearAllArrows();
            selectedTagList.Clear();
            lblDrawnWord.Text = "";
            lastTag = null;
        }





        private bool IsBoardEmpty()
        {
            char[,] board = new char[GRID_MAX, GRID_MAX];

            board = updateBoard(flowLayoutPanelMain);

            for (int r = 0; r < GRID_MAX; r++)
            {
                for (int c = 0; c < GRID_MAX; c++)
                {
                    if (board[r, c] != '.')
                        return false;
                }
            }

            return true;

        }

        private void lbl_MouseUp(object sender, MouseEventArgs e)
        {
            clearStyles();
            clearAllArrows();
            selectedTagList.Clear();
            lblDrawnWord.Text = "";
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {

            Label lbl = sender as Label;
            DoDragDrop(lbl.Text, DragDropEffects.All);
        }

        private void generateBoard()
        {
            var chars = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            var stringChars = new char[GRID_MAX * GRID_MAX];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            for (int i = 0; i < 100; i++)
            {
                int row = (int)(i / GRID_MAX);
                int col = i % GRID_MAX;
                board[row, col] = stringChars[i];
            }
        }



        private void removeCell(ucCell ucCell)
        {


            FlowLayoutPanel flwPnl = ucCell.Parent as FlowLayoutPanel;
            flwPnl.Controls.Remove(ucCell);

            if (flwPnl.Controls.Count == 0)
            {
                flowLayoutPanelMain.Controls.Remove(flwPnl);
            }
        }

        private void F_WordCrush_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M)
            {
                // Cheat :)
                SolveAuto();
            }
        }

        private async void SolveAuto()
        {
            char[,] board = new char[GRID_MAX, GRID_MAX];

            board = updateBoard(flowLayoutPanelMain);

            for (int r = 0; r < GRID_MAX; r++)
            {
                for (int c = 0; c < GRID_MAX; c++)
                {
                    if (board[r, c] == '.') continue;

                    char chToFind = charConvert(board[r, c]);
                    HashSet<string> possibleWords = DctCharVsWordList[chToFind];


                    foreach (var word in possibleWords.Where(w => w.Length >= 2))
                    {
                        if (findWord(board, r, c, word.Remove(0, 1), ""))
                        {
                            await Task.Run(() =>
                            {

                                System.Threading.Thread.Sleep(100);

                            });


                            int cnt = flowLayoutPanelScores.Controls.Count;
                            ucWordRow wr = new ucWordRow()
                            {
                                Score = word.Length * word.Length + cnt,
                                Word = word
                            };
                            wr.updateUI(cnt);

                            flowLayoutPanelScores.Controls.Add(wr);
                            flowLayoutPanelScores.ScrollControlIntoView(wr);

                            TotalScore += wr.Score;
                            lblTotalScore.Text = TotalScore.ToString().PadLeft(5, '0');

                            foreach (ucCell cell in selectedTagList)
                            {
                                removeCell(cell);
                            }

                            board = updateBoard(flowLayoutPanelMain);
                        }
                    }
                }
            }

        }

        private bool IsSolvable()
        {
            char[,] board = new char[GRID_MAX, GRID_MAX];

            board = updateBoard(flowLayoutPanelMain);

            for (int r = 0; r < GRID_MAX; r++)
            {
                for (int c = 0; c < GRID_MAX; c++)
                {


                    if (board[r, c] == '.') continue;

                    char chToFind = charConvert(board[r, c]);
                    HashSet<string> possibleWords = DctCharVsWordList[chToFind];


                    foreach (var word in possibleWords.Where(w => w.Length >= 2))
                    {
                        if (findWord(board, r, c, word.Remove(0, 1), ""))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        private char[,] updateBoard(FlowLayoutPanel flwContainer)
        {
            char[,] board = new char[GRID_MAX, GRID_MAX];


            for (int r = 0; r < GRID_MAX; r++)
            {
                for (int c = 0; c < GRID_MAX; c++)
                {
                    board[r, c] = '.';
                }
            }

            int rCnt = GRID_MAX - 1, cCnt = 0;
            foreach (var cnt in flwContainer.Controls)
            {
                if (cnt is FlowLayoutPanel)
                {

                    FlowLayoutPanel flwPnl = cnt as FlowLayoutPanel;

                    rCnt = GRID_MAX - 1;
                    foreach (var cell in flwPnl.Controls)
                    {
                        board[rCnt, cCnt] = (cell as ucCell).GetLabel().Text.First();

                        rCnt--;
                    }
                }

                cCnt++;
            }


            return board;
        }

        private void F_WordCrush_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Wordy Crush is a word puzzle game with the 8 direction moves.");
            sb.AppendLine("");
            sb.AppendLine(" # Supported Lanugage DB(s): ");
            sb.AppendLine(" + Turkish");
            sb.AppendLine(" + English");
            sb.AppendLine("");
            sb.AppendLine(" # Scoring: ");
            sb.AppendLine(" + Word length ^ 3");
            sb.AppendLine(" + Word index");
            sb.AppendLine(" + Bonus: 10.000 when all board is cleared.");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Created by Mehmet Cakir, 2022");
            MessageBox.Show(sb.ToString(), "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void F_WordCrush_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(e);
        }

        private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_WordCrush_HelpButtonClicked(sender,

            new CancelEventArgs());
        }
    }

    public enum EGameMode
    {
        FLOATING,
        STATIC
    }

    public enum ELanguage
    {
        TR,
        EN,
        DE,
        FR,
        IT,
        ES,
        NL
    }
}