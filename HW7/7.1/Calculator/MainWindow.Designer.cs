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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Calculate = new System.Windows.Forms.Button();
            this.Point = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.Sign = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.One = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Divivide = new System.Windows.Forms.Button();
            this.Backspace = new System.Windows.Forms.Button();
            this.Sqrt = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.Label();
            this.EraseAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Calculate, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.Point, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.Zero, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Sign, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Plus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Three, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Two, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.One, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Minus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Six, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Five, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Four, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Multiply, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Nine, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Eight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Seven, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Divivide, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Backspace, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Sqrt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.OutputBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EraseAll, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 411);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Calculate
            // 
            this.Calculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Calculate.Location = new System.Drawing.Point(276, 363);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(85, 45);
            this.Calculate.TabIndex = 20;
            this.Calculate.Text = "=";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.OnButton);
            // 
            // Point
            // 
            this.Point.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Point.Location = new System.Drawing.Point(185, 363);
            this.Point.Name = "Point";
            this.Point.Size = new System.Drawing.Size(85, 45);
            this.Point.TabIndex = 19;
            this.Point.Text = ",";
            this.Point.UseVisualStyleBackColor = true;
            this.Point.Click += new System.EventHandler(this.OnButton);
            // 
            // Zero
            // 
            this.Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zero.Location = new System.Drawing.Point(94, 363);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(85, 45);
            this.Zero.TabIndex = 18;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.OnButton);
            // 
            // Sign
            // 
            this.Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sign.Location = new System.Drawing.Point(3, 363);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(85, 45);
            this.Sign.TabIndex = 17;
            this.Sign.Text = "+/-";
            this.Sign.UseVisualStyleBackColor = true;
            this.Sign.Click += new System.EventHandler(this.OnButton);
            // 
            // Plus
            // 
            this.Plus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Plus.Location = new System.Drawing.Point(276, 314);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(85, 43);
            this.Plus.TabIndex = 16;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.OnButton);
            // 
            // Three
            // 
            this.Three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Three.Location = new System.Drawing.Point(185, 314);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(85, 43);
            this.Three.TabIndex = 15;
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.OnButton);
            // 
            // Two
            // 
            this.Two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Two.Location = new System.Drawing.Point(94, 314);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(85, 43);
            this.Two.TabIndex = 14;
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.OnButton);
            // 
            // One
            // 
            this.One.Dock = System.Windows.Forms.DockStyle.Fill;
            this.One.Location = new System.Drawing.Point(3, 314);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(85, 43);
            this.One.TabIndex = 13;
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.OnButton);
            // 
            // Minus
            // 
            this.Minus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Minus.Location = new System.Drawing.Point(276, 265);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(85, 43);
            this.Minus.TabIndex = 12;
            this.Minus.Text = "-";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.OnButton);
            // 
            // Six
            // 
            this.Six.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Six.Location = new System.Drawing.Point(185, 265);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(85, 43);
            this.Six.TabIndex = 11;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.OnButton);
            // 
            // Five
            // 
            this.Five.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Five.Location = new System.Drawing.Point(94, 265);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(85, 43);
            this.Five.TabIndex = 10;
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.OnButton);
            // 
            // Four
            // 
            this.Four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Four.Location = new System.Drawing.Point(3, 265);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(85, 43);
            this.Four.TabIndex = 9;
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.OnButton);
            // Multiply
            // 
            this.Multiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Multiply.Location = new System.Drawing.Point(276, 216);
            this.Multiply.Name = "Multiply";
            this.Multiply.Size = new System.Drawing.Size(85, 43);
            this.Multiply.TabIndex = 8;
            this.Multiply.Text = "*";
            this.Multiply.UseVisualStyleBackColor = true;
            this.Multiply.Click += new System.EventHandler(this.OnButton);
            // 
            // Nine
            // 
            this.Nine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nine.Location = new System.Drawing.Point(185, 216);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(85, 43);
            this.Nine.TabIndex = 7;
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.OnButton);
            // 
            // Eight
            // 
            this.Eight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eight.Location = new System.Drawing.Point(94, 216);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(85, 43);
            this.Eight.TabIndex = 6;
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.OnButton);
            // 
            // Seven
            // 
            this.Seven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Seven.Location = new System.Drawing.Point(3, 216);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(85, 43);
            this.Seven.TabIndex = 5;
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.OnButton);
            // 
            // Divivide
            // 
            this.Divivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Divivide.Location = new System.Drawing.Point(276, 167);
            this.Divivide.Name = "Divivide";
            this.Divivide.Size = new System.Drawing.Size(85, 43);
            this.Divivide.TabIndex = 4;
            this.Divivide.Text = "/";
            this.Divivide.UseVisualStyleBackColor = true;
            this.Divivide.Click += new System.EventHandler(this.OnButton);
            // 
            // Backspace
            // 
            this.Backspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Backspace.Location = new System.Drawing.Point(185, 167);
            this.Backspace.Name = "Backspace";
            this.Backspace.Size = new System.Drawing.Size(85, 43);
            this.Backspace.TabIndex = 3;
            this.Backspace.Text = "⌫";
            this.Backspace.UseVisualStyleBackColor = true;
            this.Backspace.Click += new System.EventHandler(this.OnButton);
            // 
            // Sqrt
            // 
            this.Sqrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sqrt.Location = new System.Drawing.Point(94, 167);
            this.Sqrt.Name = "Sqrt";
            this.Sqrt.Size = new System.Drawing.Size(85, 43);
            this.Sqrt.TabIndex = 2;
            this.Sqrt.Text = "√‎";
            this.Sqrt.UseVisualStyleBackColor = true;
            this.Sqrt.Click += new System.EventHandler(this.OnButton);
            // 
            // OutputBox
            // 
            this.OutputBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.OutputBox, 4);
            this.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputBox.Location = new System.Drawing.Point(3, 0);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(358, 164);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EraseAll
            // 
            this.EraseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EraseAll.Location = new System.Drawing.Point(3, 167);
            this.EraseAll.Name = "EraseAll";
            this.EraseAll.Size = new System.Drawing.Size(85, 43);
            this.EraseAll.TabIndex = 1;
            this.EraseAll.Text = "C";
            this.EraseAll.UseVisualStyleBackColor = true;
            this.EraseAll.Click += new System.EventHandler(this.OnButton);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(380, 450);
            this.Name = "MainWindow";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label OutputBox;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button Point;
        private System.Windows.Forms.Button Zero;
        private System.Windows.Forms.Button Sign;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button Five;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.Button Nine;
        private System.Windows.Forms.Button Eight;
        private System.Windows.Forms.Button Seven;
        private System.Windows.Forms.Button Divivide;
        private System.Windows.Forms.Button Backspace;
        private System.Windows.Forms.Button Sqrt;
        private System.Windows.Forms.Button EraseAll;
    }
}

