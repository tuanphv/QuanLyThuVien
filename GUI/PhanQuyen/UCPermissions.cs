using DTO;
using System.ComponentModel;

namespace GUI.PhanQuyen
{
    public partial class UCPermissions : UserControl
    {
        BindingList<NhomNguoiDungDTO> list = new BindingList<NhomNguoiDungDTO>();
        public UCPermissions()
        {
            InitializeComponent();
        }

        private void UCPermissions_Load(object sender, EventArgs e)
        {
            list = BUS.NhomNguoiDungBUS.GetAllNhomNguoiDung();
            actionDataGridView1.DataSource = list;
        }
    }
}
