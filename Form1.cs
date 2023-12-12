namespace FieldOfMiracles
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int currentScore = 0;
        string answer;
        bool isBaraban = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int wordsCount = 5;
            string[] questions = new string[wordsCount];
            questions[0] = "2 + 2 * 2";
            questions[1] = "3 + 3 * 3";
            questions[2] = "4 + 4 * 4";
            questions[3] = "5 + 5 * 5";
            questions[4] = "2 + 2 * 6";

            string[] answers = new string[wordsCount];
            answers[0] = "ШЕСТЬ";
            answers[1] = "ДВЕНАДЦАТЬ";
            answers[2] = "ДВАДЦАТЬ";
            answers[3] = "ТРИДЦАТЬ";
            answers[4] = "ЧЕТЫРНАДЦАТЬ";


            var randomQuestionIndex = random.Next(questions.Length);

            quetionLabel.Text = questions[randomQuestionIndex];

            answer = answers[randomQuestionIndex];
            string word = "";
            for (int i = 0; i < answer.Length; i++)
            {
                word += "*";
            }
            wordLabel.Text = word;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randomScore = random.Next(1000);
            randomScoreLabel.Text = randomScore.ToString();
            currentScore += randomScore;
            scoreLabel.Text = currentScore.ToString();
            isBaraban = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(!isBaraban) 
            {
                MessageBox.Show("Крутите барабан!");
                return;
            }
            Label symbol = (Label)sender;

            string word = wordLabel.Text;
            string newWord = "";
            for (int i = 0;i < word.Length;i++)
            {
                if (answer[i].ToString() == symbol.Text)
                {
                    newWord += answer[i];
                }
                else
                {
                    newWord += word[i];
                }
            }
            wordLabel.Text = newWord;
            
            if(newWord == answer)
            {
                MessageBox.Show("Вы угадали слово!");
            }

            if(word == newWord)
            {
                MessageBox.Show($"Буквы {symbol.Text} нет в загаданом слове!");
            }
            isBaraban = false;
        }
    }
}