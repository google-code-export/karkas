using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.Core.DataUtil
{
    public class ParameterBuilder
    {

        private SqlCommand command;

        public SqlCommand Command
        {
            get { return command; }
            set { command = value; }
        }
        public ParameterBuilder(SqlCommand pCommand)
        {
            this.command = pCommand;
        }
        public void parameterEkle(string parameterName, object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parameterName;
            paramDbTipiniSetle(prm, value);
            prm.Value = value;
            command.Parameters.Add(prm);
        }
        public void parameterEkle(string parameterName, object value, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parameterName;
            paramDbTipiniSetle(prm, value);
            prm.Value = value;
            prm.Size = size;
            command.Parameters.Add(prm);
        }


        private void paramDbTipiniSetle(SqlParameter prm, string value)
        {
            prm.SqlDbType = SqlDbType.VarChar;
        }
        private void paramDbTipiniSetle(SqlParameter prm, int value)
        {
            prm.SqlDbType = SqlDbType.Int;
        }
        private void paramDbTipiniSetle(SqlParameter prm, Guid value)
        {
            prm.SqlDbType = SqlDbType.UniqueIdentifier;
        }
        private void paramDbTipiniSetle(SqlParameter prm, long value)
        {
            prm.SqlDbType = SqlDbType.BigInt;
        }
        private void paramDbTipiniSetle(SqlParameter prm, byte value)
        {
            prm.SqlDbType = SqlDbType.TinyInt;
        }
        private void paramDbTipiniSetle(SqlParameter prm, byte[] value)
        {
            prm.SqlDbType = SqlDbType.Binary;
        }
        private void paramDbTipiniSetle(SqlParameter prm, bool value)
        {
            prm.SqlDbType = SqlDbType.Bit;
        }
        private void paramDbTipiniSetle(SqlParameter prm, object value)
        {
        }


    }
}
