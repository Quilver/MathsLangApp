namespace MathsLangApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WriteHere = new System.Windows.Forms.Label();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MathsGraph = new System.Windows.Forms.PictureBox();
            this.ResetGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MathsGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // WriteHere
            // 
            this.WriteHere.AutoSize = true;
            this.WriteHere.Location = new System.Drawing.Point(6, 31);
            this.WriteHere.Name = "WriteHere";
            this.WriteHere.Size = new System.Drawing.Size(84, 15);
            this.WriteHere.TabIndex = 0;
            this.WriteHere.Text = "Enter equation";
            // 
            // UserInput
            // 
            this.UserInput.AcceptsReturn = true;
            this.UserInput.Location = new System.Drawing.Point(96, 28);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(100, 23);
            this.UserInput.TabIndex = 1;
            this.UserInput.TextChanged += new System.EventHandler(this.UserInput_TextChanged);
            this.UserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInput_KeyDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Solution";
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(82, 57);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(168, 23);
            this.Output.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MathsGraph
            // 
            this.MathsGraph.Location = new System.Drawing.Point(284, 12);
            this.MathsGraph.Name = "MathsGraph";
            this.MathsGraph.Size = new System.Drawing.Size(600, 600);
            this.MathsGraph.TabIndex = 5;
            this.MathsGraph.TabStop = false;
            // 
            // ResetGraph
            // 
            this.ResetGraph.Location = new System.Drawing.Point(82, 86);
            this.ResetGraph.Name = "ResetGraph";
            this.ResetGraph.Size = new System.Drawing.Size(114, 23);
            this.ResetGraph.TabIndex = 6;
            this.ResetGraph.Text = "Reset graph";
            this.ResetGraph.UseVisualStyleBackColor = true;
            this.ResetGraph.Click += new System.EventHandler(this.ResetGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 625);
            this.Controls.Add(this.ResetGraph);
            this.Controls.Add(this.MathsGraph);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.WriteHere);
            this.Name = "Form1";
            this.Text = "Equation interpreter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MathsGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //MathsLangApp.Graph.Start();
        private Label WriteHere;
        private TextBox UserInput;
        private Label label1;
        private TextBox Output;
        private Button button1;
        private PictureBox MathsGraph;
        private Button ResetGraph;
    }
}