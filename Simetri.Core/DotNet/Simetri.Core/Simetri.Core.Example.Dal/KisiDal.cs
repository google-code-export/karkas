using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.DataUtil;
using System.Data;
using System.Data.SqlClient;

namespace Simetri.Core.Example.Dal
{
    public class KisiDal : BaseDal<Kisi,Guid>
    {


        public override string SelectString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        protected override string InsertString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        protected override string UpdateString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        protected override string DeleteString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        protected override bool IdentityVarMi
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        protected override void ProcessRow(IDataReader dr, Kisi row)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void InsertCommandParametersAdd(SqlCommand Cmd, Kisi row)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void UpdateCommandParametersAdd(SqlCommand Cmd, Kisi row)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void DeleteCommandParametersAdd(SqlCommand Cmd, Kisi row)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
