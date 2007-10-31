using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;
using Simetri.Core.Validation.ForPonos;
using System.Data;

namespace Simetri.Core.TypeLibrary.Ornekler
{
	[Serializable]
	public partial class 	OrnekIdentityPkTable	
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
	{
		private int id;
		private string adi;
		private string soyadi;

		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (id!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				id = value;
			}
		}

		public string Adi
		{
			get
			{
				return adi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (adi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				adi = value;
			}
		}

		public string Soyadi
		{
			get
			{
				return soyadi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (soyadi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				soyadi = value;
			}
		}


	protected override void ValidationListesiniOlusturCodeGeneration()
	{		
		this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "		Adi		"));		
		this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "		Soyadi		"));	
	}
	}
}
