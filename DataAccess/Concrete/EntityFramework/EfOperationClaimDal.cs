﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfOperationClaimDal:EfEntityRepositoryBase<OperationClaim,ReCapContext>,IOperationClaimDal
	{
	}
}
