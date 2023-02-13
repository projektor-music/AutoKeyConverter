using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_file = new System.Windows.Forms.Label();
            this.txt_file_select = new System.Windows.Forms.TextBox();
            this.btn_file_open = new System.Windows.Forms.Button();
            this.btn_convert = new System.Windows.Forms.Button();
            this.btn_file_process = new System.Windows.Forms.Button();
            this.lbl_fps = new System.Windows.Forms.Label();
            this.lbl_bpm = new System.Windows.Forms.Label();
            this.txt_fps = new System.Windows.Forms.TextBox();
            this.txt_bpm = new System.Windows.Forms.TextBox();
            this.lst_deselected = new System.Windows.Forms.ListView();
            this.deselected_main = new System.Windows.Forms.ColumnHeader();
            this.lst_selected = new System.Windows.Forms.ListView();
            this.selected_main = new System.Windows.Forms.ColumnHeader();
            this.btn_lane_select = new System.Windows.Forms.Button();
            this.btn_lane_deselect = new System.Windows.Forms.Button();
            this.btn_select_all = new System.Windows.Forms.Button();
            this.btn_deselect_all = new System.Windows.Forms.Button();
            this.txt_min = new System.Windows.Forms.TextBox();
            this.lbl_min = new System.Windows.Forms.Label();
            this.txt_max = new System.Windows.Forms.TextBox();
            this.lbl_max = new System.Windows.Forms.Label();
            this.chb_normalize = new System.Windows.Forms.CheckBox();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_file
            // 
            this.lbl_file.AutoSize = true;
            this.lbl_file.Location = new System.Drawing.Point(10, 7);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(62, 15);
            this.lbl_file.TabIndex = 0;
            this.lbl_file.Text = "Select File:";
            // 
            // txt_file_select
            // 
            this.txt_file_select.Location = new System.Drawing.Point(85, 5);
            this.txt_file_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_file_select.Name = "txt_file_select";
            this.txt_file_select.Size = new System.Drawing.Size(771, 23);
            this.txt_file_select.TabIndex = 1;
            // 
            // btn_file_open
            // 
            this.btn_file_open.Location = new System.Drawing.Point(862, 5);
            this.btn_file_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_file_open.Name = "btn_file_open";
            this.btn_file_open.Size = new System.Drawing.Size(66, 22);
            this.btn_file_open.TabIndex = 2;
            this.btn_file_open.Text = "Open";
            this.btn_file_open.UseVisualStyleBackColor = true;
            this.btn_file_open.Click += new System.EventHandler(this.btn_file_open_Click);
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(862, 256);
            this.btn_convert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(66, 22);
            this.btn_convert.TabIndex = 4;
            this.btn_convert.Text = "Convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // btn_file_process
            // 
            this.btn_file_process.Location = new System.Drawing.Point(862, 30);
            this.btn_file_process.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_file_process.Name = "btn_file_process";
            this.btn_file_process.Size = new System.Drawing.Size(66, 22);
            this.btn_file_process.TabIndex = 6;
            this.btn_file_process.Text = "Process";
            this.btn_file_process.UseVisualStyleBackColor = true;
            this.btn_file_process.Click += new System.EventHandler(this.btn_file_process_Click);
            // 
            // lbl_fps
            // 
            this.lbl_fps.AutoSize = true;
            this.lbl_fps.Location = new System.Drawing.Point(10, 34);
            this.lbl_fps.Name = "lbl_fps";
            this.lbl_fps.Size = new System.Drawing.Size(29, 15);
            this.lbl_fps.TabIndex = 7;
            this.lbl_fps.Text = "FPS:";
            // 
            // lbl_bpm
            // 
            this.lbl_bpm.AutoSize = true;
            this.lbl_bpm.Location = new System.Drawing.Point(85, 34);
            this.lbl_bpm.Name = "lbl_bpm";
            this.lbl_bpm.Size = new System.Drawing.Size(35, 15);
            this.lbl_bpm.TabIndex = 8;
            this.lbl_bpm.Text = "BPM:";
            // 
            // txt_fps
            // 
            this.txt_fps.Location = new System.Drawing.Point(45, 31);
            this.txt_fps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_fps.Name = "txt_fps";
            this.txt_fps.Size = new System.Drawing.Size(34, 23);
            this.txt_fps.TabIndex = 10;
            this.txt_fps.Text = "30";
            this.txt_fps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fps_KeyPress);
            // 
            // txt_bpm
            // 
            this.txt_bpm.Location = new System.Drawing.Point(126, 31);
            this.txt_bpm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_bpm.Name = "txt_bpm";
            this.txt_bpm.Size = new System.Drawing.Size(34, 23);
            this.txt_bpm.TabIndex = 11;
            this.txt_bpm.Text = "145";
            this.txt_bpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_bpm_KeyPress);
            // 
            // lst_deselected
            // 
            this.lst_deselected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deselected_main});
            this.lst_deselected.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_deselected.Location = new System.Drawing.Point(10, 60);
            this.lst_deselected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lst_deselected.Name = "lst_deselected";
            this.lst_deselected.Size = new System.Drawing.Size(420, 218);
            this.lst_deselected.TabIndex = 12;
            this.lst_deselected.HeaderStyle = ColumnHeaderStyle.None;
            this.lst_deselected.UseCompatibleStateImageBehavior = false;
            this.lst_deselected.View = System.Windows.Forms.View.Details;
            this.lst_deselected.SelectedIndexChanged += new System.EventHandler(this.lst_deselecxted_SelectedIndexChanged);
            // 
            // deselected_main
            // 
            this.deselected_main.Text = "";
            this.deselected_main.Width = 390;
            // 
            // lst_selected
            // 
            this.lst_selected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.selected_main});
            this.lst_selected.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_selected.Location = new System.Drawing.Point(436, 60);
            this.lst_selected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lst_selected.Name = "lst_selected";
            this.lst_selected.ShowItemToolTips = true;
            this.lst_selected.Size = new System.Drawing.Size(420, 218);
            this.lst_selected.TabIndex = 13;
            this.lst_selected.HeaderStyle = ColumnHeaderStyle.None;
            this.lst_selected.UseCompatibleStateImageBehavior = false;
            this.lst_selected.View = System.Windows.Forms.View.Details;
            this.lst_selected.SelectedIndexChanged += new System.EventHandler(this.lst_selected_SelectedIndexChanged);
            // 
            // selected_main
            // 
            this.selected_main.Text = "";
            this.selected_main.Width = 390;
            // 
            // btn_lane_select
            // 
            this.btn_lane_select.Enabled = false;
            this.btn_lane_select.Location = new System.Drawing.Point(862, 60);
            this.btn_lane_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_lane_select.Name = "btn_lane_select";
            this.btn_lane_select.Size = new System.Drawing.Size(66, 22);
            this.btn_lane_select.TabIndex = 14;
            this.btn_lane_select.Text = "Select";
            this.btn_lane_select.UseVisualStyleBackColor = true;
            this.btn_lane_select.Click += new System.EventHandler(this.btn_lane_select_Click);
            // 
            // btn_lane_deselect
            // 
            this.btn_lane_deselect.Enabled = false;
            this.btn_lane_deselect.Location = new System.Drawing.Point(862, 86);
            this.btn_lane_deselect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_lane_deselect.Name = "btn_lane_deselect";
            this.btn_lane_deselect.Size = new System.Drawing.Size(66, 22);
            this.btn_lane_deselect.TabIndex = 15;
            this.btn_lane_deselect.Text = "Deselect";
            this.btn_lane_deselect.UseVisualStyleBackColor = true;
            this.btn_lane_deselect.Click += new System.EventHandler(this.btn_lane_deselect_Click);
            // 
            // btn_select_all
            // 
            this.btn_select_all.Location = new System.Drawing.Point(862, 112);
            this.btn_select_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_select_all.Name = "btn_select_all";
            this.btn_select_all.Size = new System.Drawing.Size(66, 36);
            this.btn_select_all.TabIndex = 17;
            this.btn_select_all.Text = "Select all";
            this.btn_select_all.UseVisualStyleBackColor = true;
            this.btn_select_all.Click += new System.EventHandler(this.btn_select_all_Click);
            // 
            // btn_deselect_all
            // 
            this.btn_deselect_all.Location = new System.Drawing.Point(862, 152);
            this.btn_deselect_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_deselect_all.Name = "btn_deselect_all";
            this.btn_deselect_all.Size = new System.Drawing.Size(66, 41);
            this.btn_deselect_all.TabIndex = 18;
            this.btn_deselect_all.Text = "Deselect all";
            this.btn_deselect_all.UseVisualStyleBackColor = true;
            this.btn_deselect_all.Click += new System.EventHandler(this.btn_deselect_all_Click);
            // 
            // txt_min
            // 
            this.txt_min.Location = new System.Drawing.Point(209, 31);
            this.txt_min.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_min.Name = "txt_min";
            this.txt_min.Size = new System.Drawing.Size(34, 23);
            this.txt_min.TabIndex = 20;
            this.txt_min.Text = "0";
            // 
            // lbl_min
            // 
            this.lbl_min.AutoSize = true;
            this.lbl_min.Location = new System.Drawing.Point(167, 34);
            this.lbl_min.Name = "lbl_min";
            this.lbl_min.Size = new System.Drawing.Size(33, 15);
            this.lbl_min.TabIndex = 19;
            this.lbl_min.Text = "MIN:";
            // 
            // txt_max
            // 
            this.txt_max.Location = new System.Drawing.Point(291, 31);
            this.txt_max.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_max.Name = "txt_max";
            this.txt_max.Size = new System.Drawing.Size(34, 23);
            this.txt_max.TabIndex = 22;
            this.txt_max.Text = "100";
            // 
            // lbl_max
            // 
            this.lbl_max.AutoSize = true;
            this.lbl_max.Location = new System.Drawing.Point(249, 34);
            this.lbl_max.Name = "lbl_max";
            this.lbl_max.Size = new System.Drawing.Size(36, 15);
            this.lbl_max.TabIndex = 21;
            this.lbl_max.Text = "MAX:";
            // 
            // chb_normalize
            // 
            this.chb_normalize.AutoSize = true;
            this.chb_normalize.Location = new System.Drawing.Point(331, 33);
            this.chb_normalize.Name = "chb_normalize";
            this.chb_normalize.Size = new System.Drawing.Size(80, 19);
            this.chb_normalize.TabIndex = 23;
            this.chb_normalize.Text = "Normalize";
            this.chb_normalize.UseVisualStyleBackColor = true;
            // 
            // rtb_output
            // 
            this.rtb_output.Location = new System.Drawing.Point(10, 60);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.ReadOnly = true;
            this.rtb_output.Size = new System.Drawing.Size(846, 218);
            this.rtb_output.TabIndex = 24;
            this.rtb_output.Text = "";
            this.rtb_output.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 286);
            this.Controls.Add(this.rtb_output);
            this.Controls.Add(this.chb_normalize);
            this.Controls.Add(this.txt_max);
            this.Controls.Add(this.lbl_max);
            this.Controls.Add(this.txt_min);
            this.Controls.Add(this.lbl_min);
            this.Controls.Add(this.btn_deselect_all);
            this.Controls.Add(this.btn_select_all);
            this.Controls.Add(this.btn_lane_deselect);
            this.Controls.Add(this.btn_lane_select);
            this.Controls.Add(this.lst_selected);
            this.Controls.Add(this.lst_deselected);
            this.Controls.Add(this.txt_bpm);
            this.Controls.Add(this.txt_fps);
            this.Controls.Add(this.lbl_bpm);
            this.Controls.Add(this.lbl_fps);
            this.Controls.Add(this.btn_file_process);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.btn_file_open);
            this.Controls.Add(this.txt_file_select);
            this.Controls.Add(this.lbl_file);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Label lbl_file;
        private TextBox txt_file_select;
        private Button btn_file_open;
        private Button btn_convert;
        private Button btn_file_process;
        private Label lbl_fps;
        private Label lbl_bpm;
        private TextBox txt_fps;
        private TextBox txt_bpm;
        private ListView lst_deselected;
        private ListView lst_selected;
        private Button btn_lane_select;
        private Button btn_lane_deselect;
        private Button btn_select_all;
        private Button btn_deselect_all;
        private ColumnHeader deselected_main;
        private ColumnHeader selected_main;
        private TextBox txt_min;
        private Label lbl_min;
        private TextBox txt_max;
        private Label lbl_max;
        private CheckBox chb_normalize;
        private RichTextBox rtb_output;
    }
}
