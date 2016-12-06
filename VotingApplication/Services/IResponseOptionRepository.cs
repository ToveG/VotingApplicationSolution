using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Services
{
    public interface IResponseOptionRepository
    {
        ResponseOption CreateResponseOption(ResponseOption option, int id);
        ResponseOption UpdateResponseOption(ResponseOption option);
        void DeleteResponseOption(int id);

    }
}
