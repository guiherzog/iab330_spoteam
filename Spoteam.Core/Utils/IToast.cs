using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Utils {
    public interface IToast {
        void Show(string text);
        void ShowLong(string text);
    }
}
