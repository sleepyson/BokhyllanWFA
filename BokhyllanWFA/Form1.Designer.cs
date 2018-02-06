namespace BokhyllanWFA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userInputBoxTitel = new System.Windows.Forms.TextBox();
            this.userInputBoxSkribent = new System.Windows.Forms.TextBox();
            this.userInputBoxUtgivningsår = new System.Windows.Forms.NumericUpDown();
            this.labelUtgivningsår = new System.Windows.Forms.Label();
            this.labelSkribent = new System.Windows.Forms.Label();
            this.labelTitel = new System.Windows.Forms.Label();
            this.userInputBoxTyp = new System.Windows.Forms.ComboBox();
            this.tidskriftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelTyp = new System.Windows.Forms.Label();
            this.buttonAddNewBook = new System.Windows.Forms.Button();
            this.buttonShowBookList = new System.Windows.Forms.Button();
            this.buttonEraseBookList = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.userInputBoxUtgivningsår)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tidskriftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bokBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // userInputBoxTitel
            // 
            this.userInputBoxTitel.Location = new System.Drawing.Point(10, 30);
            this.userInputBoxTitel.Name = "userInputBoxTitel";
            this.userInputBoxTitel.Size = new System.Drawing.Size(170, 20);
            this.userInputBoxTitel.TabIndex = 1;
            // 
            // userInputBoxSkribent
            // 
            this.userInputBoxSkribent.Location = new System.Drawing.Point(10, 80);
            this.userInputBoxSkribent.Name = "userInputBoxSkribent";
            this.userInputBoxSkribent.Size = new System.Drawing.Size(170, 20);
            this.userInputBoxSkribent.TabIndex = 2;
            // 
            // userInputBoxUtgivningsår
            // 
            this.userInputBoxUtgivningsår.Location = new System.Drawing.Point(95, 168);
            this.userInputBoxUtgivningsår.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.userInputBoxUtgivningsår.Name = "userInputBoxUtgivningsår";
            this.userInputBoxUtgivningsår.Size = new System.Drawing.Size(85, 20);
            this.userInputBoxUtgivningsår.TabIndex = 3;
            this.userInputBoxUtgivningsår.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelUtgivningsår
            // 
            this.labelUtgivningsår.AutoSize = true;
            this.labelUtgivningsår.Location = new System.Drawing.Point(10, 170);
            this.labelUtgivningsår.Name = "labelUtgivningsår";
            this.labelUtgivningsår.Size = new System.Drawing.Size(69, 13);
            this.labelUtgivningsår.TabIndex = 4;
            this.labelUtgivningsår.Text = "Utgivningsår:";
            // 
            // labelSkribent
            // 
            this.labelSkribent.AutoSize = true;
            this.labelSkribent.Location = new System.Drawing.Point(10, 60);
            this.labelSkribent.Name = "labelSkribent";
            this.labelSkribent.Size = new System.Drawing.Size(49, 13);
            this.labelSkribent.TabIndex = 5;
            this.labelSkribent.Text = "Skribent:";
            // 
            // labelTitel
            // 
            this.labelTitel.AutoSize = true;
            this.labelTitel.Location = new System.Drawing.Point(10, 10);
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.Size = new System.Drawing.Size(30, 13);
            this.labelTitel.TabIndex = 6;
            this.labelTitel.Text = "Titel:";
            // 
            // userInputBoxTyp
            // 
            this.userInputBoxTyp.FormattingEnabled = true;
            this.userInputBoxTyp.Items.AddRange(new object[] {
            "Grafisk Novell",
            "Tidskrift",
            "Roman"});
            this.userInputBoxTyp.Location = new System.Drawing.Point(10, 130);
            this.userInputBoxTyp.Name = "userInputBoxTyp";
            this.userInputBoxTyp.Size = new System.Drawing.Size(170, 21);
            this.userInputBoxTyp.TabIndex = 7;
            // 
            // tidskriftBindingSource
            // 
            this.tidskriftBindingSource.DataSource = typeof(BokhyllanWFA.Program.Tidskrift);
            // 
            // bokBindingSource
            // 
            this.bokBindingSource.DataSource = typeof(BokhyllanWFA.Program.Bok);
            // 
            // labelTyp
            // 
            this.labelTyp.AutoSize = true;
            this.labelTyp.Location = new System.Drawing.Point(10, 110);
            this.labelTyp.Name = "labelTyp";
            this.labelTyp.Size = new System.Drawing.Size(28, 13);
            this.labelTyp.TabIndex = 8;
            this.labelTyp.Text = "Typ:";
            // 
            // buttonAddNewBook
            // 
            this.buttonAddNewBook.Location = new System.Drawing.Point(189, 23);
            this.buttonAddNewBook.Name = "buttonAddNewBook";
            this.buttonAddNewBook.Size = new System.Drawing.Size(85, 50);
            this.buttonAddNewBook.TabIndex = 9;
            this.buttonAddNewBook.Text = "Lägg till bok";
            this.buttonAddNewBook.UseVisualStyleBackColor = true;
            this.buttonAddNewBook.Click += new System.EventHandler(this.ButtonAddNewBook_Click);
            // 
            // buttonShowBookList
            // 
            this.buttonShowBookList.Location = new System.Drawing.Point(189, 80);
            this.buttonShowBookList.Name = "buttonShowBookList";
            this.buttonShowBookList.Size = new System.Drawing.Size(85, 50);
            this.buttonShowBookList.TabIndex = 10;
            this.buttonShowBookList.Text = "Uppdatera listan";
            this.buttonShowBookList.UseVisualStyleBackColor = true;
            this.buttonShowBookList.Click += new System.EventHandler(this.ButtonShowBookList_Click);
            // 
            // buttonEraseBookList
            // 
            this.buttonEraseBookList.Location = new System.Drawing.Point(189, 138);
            this.buttonEraseBookList.Name = "buttonEraseBookList";
            this.buttonEraseBookList.Size = new System.Drawing.Size(85, 50);
            this.buttonEraseBookList.TabIndex = 11;
            this.buttonEraseBookList.Text = "Radera alla böcker";
            this.buttonEraseBookList.UseVisualStyleBackColor = true;
            this.buttonEraseBookList.Click += new System.EventHandler(this.ButtonEraseBookList_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(11, 203);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(263, 228);
            this.outputBox.TabIndex = 12;
            this.outputBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(286, 443);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.buttonEraseBookList);
            this.Controls.Add(this.buttonShowBookList);
            this.Controls.Add(this.buttonAddNewBook);
            this.Controls.Add(this.labelTyp);
            this.Controls.Add(this.userInputBoxTyp);
            this.Controls.Add(this.labelTitel);
            this.Controls.Add(this.labelSkribent);
            this.Controls.Add(this.labelUtgivningsår);
            this.Controls.Add(this.userInputBoxUtgivningsår);
            this.Controls.Add(this.userInputBoxSkribent);
            this.Controls.Add(this.userInputBoxTitel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bokhyllan WFA";
            ((System.ComponentModel.ISupportInitialize)(this.userInputBoxUtgivningsår)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tidskriftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bokBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox userInputBoxTitel;
        private System.Windows.Forms.TextBox userInputBoxSkribent;
        private System.Windows.Forms.NumericUpDown userInputBoxUtgivningsår;
        private System.Windows.Forms.Label labelUtgivningsår;
        private System.Windows.Forms.Label labelSkribent;
        private System.Windows.Forms.Label labelTitel;
        private System.Windows.Forms.ComboBox userInputBoxTyp;
        private System.Windows.Forms.BindingSource tidskriftBindingSource;
        private System.Windows.Forms.BindingSource bokBindingSource;
        private System.Windows.Forms.Label labelTyp;
        private System.Windows.Forms.Button buttonAddNewBook;
        private System.Windows.Forms.Button buttonShowBookList;
        private System.Windows.Forms.Button buttonEraseBookList;
        private System.Windows.Forms.RichTextBox outputBox;
    }
}

