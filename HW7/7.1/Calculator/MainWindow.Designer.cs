namespace Calculator
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.One = new System.Windows.Forms.Button();
            this.Point = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Sign = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Calculate = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.EraseAll = new System.Windows.Forms.Button();
            this.Backspace = new System.Windows.Forms.Button();
            this.Sqrt = new System.Windows.Forms.Button();
            this.Divide = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // One
            // 
            this.One.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.One.Location = new System.Drawing.Point(3, 55);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(81, 46);
            this.One.TabIndex = 0;
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.One_Click);
            // 
            // Point
            // 
            this.Point.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Point.Location = new System.Drawing.Point(177, 211);
            this.Point.Name = "Point";
            this.Point.Size = new System.Drawing.Size(81, 46);
            this.Point.TabIndex = 1;
            this.Point.Text = ",";
            this.Point.UseVisualStyleBackColor = true;
            this.Point.Click += new System.EventHandler(this.Point_Click);
            // 
            // Nine
            // 
            this.Nine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Nine.Location = new System.Drawing.Point(177, 159);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(81, 46);
            this.Nine.TabIndex = 2;
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.Nine_Click);
            // 
            // Six
            // 
            this.Six.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Six.Location = new System.Drawing.Point(177, 107);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(81, 46);
            this.Six.TabIndex = 3;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.Six_Click);
            // 
            // Three
            // 
            this.Three.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Three.Location = new System.Drawing.Point(90, 55);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(81, 46);
            this.Three.TabIndex = 4;
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.Three_Click);
            // 
            // Zero
            // 
            this.Zero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Zero.Location = new System.Drawing.Point(90, 211);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(81, 46);
            this.Zero.TabIndex = 5;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.Zero_Click);
            // 
            // Eight
            // 
            this.Eight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Eight.Location = new System.Drawing.Point(90, 159);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(81, 46);
            this.Eight.TabIndex = 6;
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.Eight_Click);
            // 
            // Five
            // 
            this.Five.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Five.Location = new System.Drawing.Point(90, 107);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(81, 46);
            this.Five.TabIndex = 7;
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.Five_Click);
            // 
            // Two
            // 
            this.Two.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Two.Location = new System.Drawing.Point(177, 55);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(81, 46);
            this.Two.TabIndex = 8;
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.Two_Click);
            // 
            // Sign
            // 
            this.Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Sign.Location = new System.Drawing.Point(3, 211);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(81, 46);
            this.Sign.TabIndex = 9;
            this.Sign.Text = "+/-";
            this.Sign.UseVisualStyleBackColor = true;
            this.Sign.Click += new System.EventHandler(this.Sign_Click);
            // 
            // Seven
            // 
            this.Seven.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Seven.Location = new System.Drawing.Point(3, 159);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(81, 46);
            this.Seven.TabIndex = 10;
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.Seven_Click);
            // 
            // Four
            // 
            this.Four.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Four.Location = new System.Drawing.Point(3, 107);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(81, 46);
            this.Four.TabIndex = 11;
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.Four_Click);
            // 
            // Calculate
            // 
            this.Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Calculate.Location = new System.Drawing.Point(280, 211);
            this.Calculate.Name = "Calculate";
            this.Calculate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Calculate.Size = new System.Drawing.Size(81, 46);
            this.Calculate.TabIndex = 12;
            this.Calculate.Text = "=";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // Plus
            // 
            this.Plus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Plus.Location = new System.Drawing.Point(280, 159);
            this.Plus.Name = "Plus";
            this.Plus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Plus.Size = new System.Drawing.Size(81, 46);
            this.Plus.TabIndex = 13;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // Minus
            // 
            this.Minus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Minus.Location = new System.Drawing.Point(280, 107);
            this.Minus.Name = "Minus";
            this.Minus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Minus.Size = new System.Drawing.Size(81, 46);
            this.Minus.TabIndex = 14;
            this.Minus.Text = "-";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // Multiply
            // 
            this.Multiply.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Multiply.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Multiply.Location = new System.Drawing.Point(280, 55);
            this.Multiply.Name = "Multiply";
            this.Multiply.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Multiply.Size = new System.Drawing.Size(81, 46);
            this.Multiply.TabIndex = 15;
            this.Multiply.Text = "*";
            this.Multiply.UseVisualStyleBackColor = true;
            this.Multiply.Click += new System.EventHandler(this.Multiply_Click);
            // 
            // EraseAll
            // 
            this.EraseAll.Location = new System.Drawing.Point(3, 3);
            this.EraseAll.Name = "EraseAll";
            this.EraseAll.Size = new System.Drawing.Size(81, 46);
            this.EraseAll.TabIndex = 16;
            this.EraseAll.Text = "С";
            this.EraseAll.UseVisualStyleBackColor = true;
            this.EraseAll.Click += new System.EventHandler(this.EraseAll_Click);
            // 
            // Backspace
            // 
            this.Backspace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Backspace.Location = new System.Drawing.Point(90, 3);
            this.Backspace.Name = "Backspace";
            this.Backspace.Size = new System.Drawing.Size(81, 46);
            this.Backspace.TabIndex = 17;
            this.Backspace.Text = "⌫";
            this.Backspace.UseVisualStyleBackColor = true;
            this.Backspace.Click += new System.EventHandler(this.Backspace_Click);
            // 
            // Sqrt
            // 
            this.Sqrt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Sqrt.Location = new System.Drawing.Point(177, 3);
            this.Sqrt.Name = "Sqrt";
            this.Sqrt.Size = new System.Drawing.Size(81, 46);
            this.Sqrt.TabIndex = 18;
            this.Sqrt.Text = "√‎";
            this.Sqrt.UseVisualStyleBackColor = true;
            this.Sqrt.Click += new System.EventHandler(this.Sqrt_Click);
            // 
            // Divide
            // 
            this.Divide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Divide.Location = new System.Drawing.Point(280, 3);
            this.Divide.Name = "Divide";
            this.Divide.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Divide.Size = new System.Drawing.Size(81, 46);
            this.Divide.TabIndex = 19;
            this.Divide.Text = "/";
            this.Divide.UseVisualStyleBackColor = true;
            this.Divide.Click += new System.EventHandler(this.OnDivideClick);
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.Control;
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputBox.Location = new System.Drawing.Point(3, 4);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(358, 143);
            this.outputBox.TabIndex = 20;
            this.outputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Four, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Minus, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Five, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.EraseAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Three, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Plus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Six, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Seven, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Backspace, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Calculate, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Sqrt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Divide, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Sign, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Multiply, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Zero, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Point, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.One, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Nine, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Eight, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Two, 2, 1);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 290);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.outputBox);
            this.MinimumSize = new System.Drawing.Size(380, 450);
            this.Name = "MainWindow";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Point;
        private System.Windows.Forms.Button Nine;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Zero;
        private System.Windows.Forms.Button Eight;
        private System.Windows.Forms.Button Five;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button Sign;
        private System.Windows.Forms.Button Seven;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.Button EraseAll;
        private System.Windows.Forms.Button Backspace;
        private System.Windows.Forms.Button Sqrt;
        private System.Windows.Forms.Button Divide;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

