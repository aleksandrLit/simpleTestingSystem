using simpleTestingSystem.Models;
using simpleTestingSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Services
{
    /// <summary>
    /// Сервис для тестирования
    /// </summary>
    public interface ITestingService
    {
        /// <summary>
        /// В случайном порядке переставляет список вопросов их ответыов
        /// </summary>
        /// <param name="questions">Список вопросов</param>
        /// <returns>Список вопросов переставленных в случайном порядке</returns>
        List<TestQuestion> randomizeQuestionList(List<TestQuestion> questions);

        /// <summary>
        /// Рассчитывает оценку на основе ответов, которые дал пользователь
        /// </summary>
        /// <param name="userAnswers">Ответы пользователя</param>
        /// <param name="questions">Вопросы</param>
        /// <returns>Процент правильных ответов пользователя</returns>
        double calculateResult(Dictionary<int, int> userAnswers, List<TestQuestion> questions);

        /// <summary>
        /// Возвращает текстовое представление оценки
        /// </summary>
        /// <param name="markInProcent">Процентное соотношение правильных ответов</param>
        /// <returns>Текстовое представление оценки</returns>
        string getMarkInText(double markInProcent);

        /// <summary>
        /// Записывает результат тестирования пользователя в файл
        /// </summary>
        /// <param name="report">Информация о проведённом тестировании</param>
        void writeTextInfoResult(TestingReport report);

        /// <summary>
        /// Формирует список пар вопроса и ответа
        /// </summary>
        /// <param name="questions">Список вопросов</param>
        /// <param name="answersForQuestions">Словарь ответов на вопросы</param>
        /// <returns>списко пар</returns>
        List<Pair<string, string>> fillPairQuestionAnswer(List<TestQuestion> questions, Dictionary<int, int> answersForQuestions);
    }
}
