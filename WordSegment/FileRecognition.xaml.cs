using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordSegment
{
    /// <summary>
    /// FileRecognition.xaml 的交互逻辑
    /// </summary>
    public partial class FileRecognition : Page
    {
        /// <summary>
        /// page初始化
        /// </summary>
        public FileRecognition()
        {
            InitializeComponent();

            SetProgressValue(0);
        }

        /// <summary>
        /// 添加文件按钮响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "文档 | *.doc; *.docx; *.txt; *.pdf";
            if (ofd.ShowDialog() == true)
            {
                txtBox.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 进度条值设置
        /// </summary>
        /// <param name="nValue"></param>
        private void SetProgressValue(int nValue)
        {
            Pgb.Value = nValue;
        }

        /// <summary>
        /// 文件识别按钮响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRecognize_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = Segment.SegWords("");
        }
    }
}
