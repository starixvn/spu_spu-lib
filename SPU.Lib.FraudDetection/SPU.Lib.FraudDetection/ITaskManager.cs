using SPU.Lib.FraudDetection.BusinessManager;

namespace SPU.Lib.FraudDetection
{
    public interface ITaskManager
    {
        /// <summary>
        /// The API to add new Task to the queue for scanning.
        /// </summary>
        /// <param name="newTask">The new task.</param>
        /// <returns>True if success.</returns>
        bool AddNewTask(Task newTask);

        bool UpdateTask(Task task);

        bool RemoveTask(Task task);
    }
}