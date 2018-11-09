using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DBHelper;
using DBHelper.SQLite;

namespace FileManagement
{
    public partial class MainForm : Form
    {
        private DataSet _dataSource;
        private BHelper bHelper;
        //数据库是否可用
        private bool dbStatus;

        public MainForm()
        {
            InitializeComponent();
            bHelper = new BHelper(new SQLiteHelper($"Data Source={tb_DbName.Text};Version=3;"));
        }

        #region 界面

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            dgvMain.DataSource = _dataSource;
        }


        private void TextBoxDragEnter(object sender, DragEventArgs e)
        {
            
        }
        private void TextBoxDragDrop(object sender, DragEventArgs e)
        {
            
        }

        #endregion



        #region 数据库

        /// <summary>
        /// 查数据
        /// </summary>
        public void Query()
        {
            _dataSource = bHelper.Query("", "", "");
        }

        /// <summary>
        /// 插入
        /// </summary>
        private void Insert()
        {
            bHelper.Insert("", "", "");
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            bHelper.Update("", "", "");
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete()
        {
            bHelper.Delete("", "");
        }

        #endregion



        private void Preview()
        {
            
        }

        //连接按钮
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //SQLite
            InitialSQLite(tb_DbName.Text, bHelper);
        }

        private void InitialSQLite(string dbName, BHelper bHelper)
        {
            if (!string.IsNullOrEmpty(dbName))
            {
                if (!File.Exists(dbName))
                    MessageBox.Show(bHelper.InitialDataBaseAndDataTable(tb_DbName.Text));
            }
            else
            {
                MessageBox.Show("初始化数据库失败");
                dbStatus = false;
            }
        }
    }
}
