using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;
using Simetri.Core.Validation.ForPonos;
using System.Data;

namespace Simetri.Core.TypeLibrary.Ornekler
{
	[Serializable]
	public partial class 	OrnekGuidPkIdentityColumnTable	
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
	{
		private Guid guidPK;
		private int identityColumn;
		private string adi;
		private string soyadi;

		public Guid GuidPK
		{
			get
			{
				return guidPK;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (guidPK!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				guidPK = value;
			}
		}

		public int IdentityColumn
		{
			get
			{
				return identityColumn;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (identityColumn!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				identityColumn = value;
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
		this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "		IdentityColumn		"));		
		this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "		Adi		"));		
		this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "		Soyadi		"));	
	}
	}
}
