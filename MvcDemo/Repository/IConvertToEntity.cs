﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Repository
{
    interface IConvertToEntity<TEntity>
    {
        TEntity ConverToEntity();
    }
}