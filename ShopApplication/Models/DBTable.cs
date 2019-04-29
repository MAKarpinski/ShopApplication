using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    abstract class DBTable
    {
        public abstract void Create();

        public abstract void AddRecord();

    }

    class DBTablePrice : DBTable
    {
        public override void Create()
        {

        }

        public override void AddRecord()
        {

        }

    }

    class DBTableProduct : DBTable
    {
        public override void Create()
        {

        }

        public override void AddRecord()
        {

        }

    }
}
