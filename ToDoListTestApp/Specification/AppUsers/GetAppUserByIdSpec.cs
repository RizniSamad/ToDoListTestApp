﻿using Ardalis.Specification;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.AppUsers
{
    public class GetAppUserByIdSpec : Specification<AppUser>
    {
        public GetAppUserByIdSpec(int id) 
        {
            Query.Where(a => a.Id == id);
        }
    }
}
