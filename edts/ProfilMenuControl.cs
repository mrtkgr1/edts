using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts {
    public partial class ProfilMenuControl : UserControl {
        public event EventHandler ProfilDuzenleTiklandi;
        public event EventHandler AyarlarTiklandi;

        public ProfilMenuControl() {
            InitializeComponent();
        }
        private void btnProfile_Click(object sender, EventArgs e) {
            ProfilDuzenleTiklandi?.Invoke(this, EventArgs.Empty);
        }

        private void btnAyarlar_Click(object sender, EventArgs e) {
            AyarlarTiklandi?.Invoke(this, EventArgs.Empty);
        }
    }

}
