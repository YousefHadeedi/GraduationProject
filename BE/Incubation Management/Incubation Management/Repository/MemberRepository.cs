using Incubation_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incubation_Management.Repository
{
    public interface IMembersTbRepository
    {

        Task<ActionResult<IEnumerable<MembersTb>>> GetAllMembersTbs();
        Task<ActionResult<MembersTb>> GetMembersTbById(int id);
        Task<ActionResult<MembersTb>> AddMembersTb(MembersTb MembersTbEntity);
        Task<ActionResult<MembersTb>> UpdateMembersTb(MembersTb MembersTbEntity);
        Task<ActionResult<MembersTb>> DeleteMembersTb(int id);

    }
    public class MembersTbRepository : IMembersTbRepository
    {
        private readonly INCUBATORDBContext INCUBATORDBContext;

        public MembersTbRepository(INCUBATORDBContext INCUBATORDBContext)
        {
            this.INCUBATORDBContext = INCUBATORDBContext;
        }
        public async Task<ActionResult<IEnumerable<MembersTb>>> GetAllMembersTbs()
        {
            return await INCUBATORDBContext.MembersTbs.ToListAsync();

        }


        public async Task<ActionResult<MembersTb>> AddMembersTb(MembersTb MembersTbEntity)
        {
            if (MembersTbEntity != null)
            {

                INCUBATORDBContext.Add(MembersTbEntity);
                await INCUBATORDBContext.SaveChangesAsync();
                if (INCUBATORDBContext.MembersTbs.Find(MembersTbEntity.MemberId) == null)
                {
                    return null;
                }
                else
                {
                    return MembersTbEntity;
                }
            }
            else
            {
                return null;
            }

        }

        public async Task<ActionResult<MembersTb>> DeleteMembersTb(int id)
        {
            if (id != -1)
            {
                MembersTb ToDeleteMembersTb = INCUBATORDBContext.MembersTbs.Find(id);
                if (ToDeleteMembersTb == null)
                {
                    return null;
                }
                else
                {

                    INCUBATORDBContext.Remove(ToDeleteMembersTb);
                    await INCUBATORDBContext.SaveChangesAsync();


                    if (INCUBATORDBContext.MembersTbs.Find(id) == null)
                    {
                        return ToDeleteMembersTb;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }





        public async Task<ActionResult<MembersTb>> GetMembersTbById(int id)
        {
            if (id != -1)
            {
                if (INCUBATORDBContext.MembersTbs.Find(id) == null)
                {
                    return null;
                }
                else
                {
                    return await INCUBATORDBContext.MembersTbs.FindAsync(id);
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<ActionResult<MembersTb>> UpdateMembersTb(MembersTb MembersTbEntity)
        {

            if (MembersTbEntity != null)
            {
                INCUBATORDBContext.Entry(MembersTbEntity).State = EntityState.Modified;
                await INCUBATORDBContext.SaveChangesAsync();
                return MembersTbEntity;


            }
            return null;

        }



    }
}
