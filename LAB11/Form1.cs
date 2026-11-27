using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace LAB11
{
    public partial class Form1 : Form
    {
        private TextBox tb;
        private Label Stat;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Мои заметки";
            this.Size = new Size(800, 550);

            // Верхняя панель
            Panel panelTop = new Panel();
            panelTop.Size = new Size(800, 50);
            panelTop.BackColor = Color.LightSteelBlue;
            panelTop.Dock = DockStyle.Top;

            Label label = new Label();
            label.Text = "МОИ ЗАМЕТКИ";
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            panelTop.Controls.Add(label);

            // Нижняя панель
            Panel panelBottom = new Panel();
            panelBottom.Size = new Size(800, 50);
            panelBottom.BackColor = Color.Gainsboro;
            panelBottom.Dock = DockStyle.Bottom;

            Stat = new Label();                   
            Stat.Text = "Готово";
            Stat.Dock = DockStyle.Fill;
            Stat.TextAlign = ContentAlignment.MiddleCenter;
            Stat.Padding = new Padding(10, 0, 0, 0);
            panelBottom.Controls.Add(Stat);

            // Вкладки
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            TabPage page1 = new TabPage("Заметки");
            TabPage page2 = new TabPage("О программе");

            // Вкладка "Заметки"
            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;

            // Левая часть: список заметок
            ListBox listBox = new ListBox();
            listBox.Dock = DockStyle.Fill;
            listBox.Items.AddRange(new object[] { "Покупки", "Учёба", "Идеи" });
            split.Panel1.Controls.Add(listBox);

            Label labelLeft = new Label();
            labelLeft.Text = "Список заметок:";
            labelLeft.Dock = DockStyle.Top;
            split.Panel1.Controls.Add(labelLeft);

            // Правая часть
            GroupBox group = new GroupBox();
            group.Text = "Текст заметки";
            group.Padding = new Padding(10);
            group.Dock = DockStyle.Fill;

            tb = new TextBox();
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tb.ScrollBars = ScrollBars.Vertical;

            FlowLayoutPanel flowButtons = new FlowLayoutPanel();
            flowButtons.Dock = DockStyle.Bottom;
            flowButtons.Height = 50;
            flowButtons.FlowDirection = FlowDirection.LeftToRight;
            flowButtons.Padding = new Padding(5);

            Button btnSave = new Button();
            btnSave.Text = "Сохранить";
            btnSave.AutoSize = true;
            btnSave.Margin = new Padding(5);

            Button btnClear = new Button();
            btnClear.Text = "Очистить";
            btnClear.AutoSize = true;
            btnClear.Margin = new Padding(5);

            flowButtons.Controls.Add(btnSave);
            flowButtons.Controls.Add(btnClear);

            group.Controls.Add(tb);         
            group.Controls.Add(flowButtons);      
            split.Panel2.Controls.Add(group);

            page1.Controls.Add(split);

            // Вкладка "О программе"
            Label labelAbout = new Label();
            labelAbout.Text = "Приложение для создания заметок.\nВерсия 1.0";
            labelAbout.Dock = DockStyle.Fill;
            labelAbout.TextAlign = ContentAlignment.MiddleCenter;
            page2.Controls.Add(labelAbout);

            tabControl.TabPages.Add(page1);
            tabControl.TabPages.Add(page2);

            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;

            this.Controls.Add(tabControl);
            this.Controls.Add(panelBottom);
            this.Controls.Add(panelTop);
        }
        private void btnSave_Click (object sender, EventArgs e)
        {
            Stat.Text = "Заметка сохранена";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tb.Clear();
            Stat.Text = "Готово";
        }
    }
}
