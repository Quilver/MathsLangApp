
using MathsLangApp.Language;
using System.Diagnostics;

namespace MathsLangApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void UserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                button1.PerformClick();
            }
        }
        Graph graph;
        Bitmap image;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.button1;
            graph= new Graph();
            image= graph.GetBackground(MathsGraph.Width, MathsGraph.Height);
            MathsGraph.Image = image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Language.Parser parser= new Language.Parser();
            var output = parser.Parse(UserInput.Text);
            if (output.type == ReturnType.Valid) { Output.Text = output.outputNum.ToString(); }
            else if (output.type == ReturnType.ValidEquation) {
                MathsGraph.Image = graph.DrawLine(image, UserInput.Text);
                Output.Text = output.type.ToString();
            } 
            else { Output.Text = output.type.ToString(); }
            UserInput.Text = "";
        }

        private void ResetGraph_Click(object sender, EventArgs e)
        {
            image = graph.GetBackground(MathsGraph.Width, MathsGraph.Height);
            MathsGraph.Image = image;
        }
    }
}