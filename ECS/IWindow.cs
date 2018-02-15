using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public interface IWindow
    {
        void Open();

        void Close();

        bool RunSelfTest();

    }
}
