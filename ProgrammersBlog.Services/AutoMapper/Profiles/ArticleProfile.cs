﻿using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x=>DateTime.Now)); // Generic bir şekilde iki entity bekliyor. Biri source (neyi dönüştürmek istiyorsun), diğeri ise destination (neye dönüşmek istiyorsun) şeklindedir. 
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest=>dest.ModifiedDate, opt=>opt.MapFrom(x=>DateTime.Now));
        }
    }
}
