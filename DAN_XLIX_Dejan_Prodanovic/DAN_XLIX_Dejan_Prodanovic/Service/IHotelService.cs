﻿using DAN_XLIX_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIX_Dejan_Prodanovic.Service
{
    interface IHotelService
    {
        tblUser AddUser(tblUser user);
        tblManager AddManager(tblManager manager);
        
    }
}
