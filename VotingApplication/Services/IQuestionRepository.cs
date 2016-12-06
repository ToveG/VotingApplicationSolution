using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Services
{
    public interface IQuestionRepository
    {
        Question GetQuestionById(int id);
        List<Question> GetAllQuestions();
        List<Question> GetQuestionsWithSpecificStatus(bool status);
        Question CreateQuestion(Question question);
        Question UpdateQuestion(Question question);
        void DeleteQuestion(int id);

        ResponseOption CreateResponseOption(ResponseOption option, int id);
        ResponseOption UpdateResponseOption(ResponseOption option);
        void DeleteResponseOption(int id, int questionId);

        //List<Result> GetAllQuestionResults();
      //  List<Result> GetSpecificResult(int questionId);
      //  Result SaveAnswer(Result result);

    }
}
