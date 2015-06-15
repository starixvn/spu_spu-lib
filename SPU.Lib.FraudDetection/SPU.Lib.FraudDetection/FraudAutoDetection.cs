//using SPU.Lib.FraudDetection.BusinessManager;
//using SPU.Lib.FraudDetection.SendingTasks;

//namespace SPU.Lib.FraudDetection
//{
//    ///// <summary>
//    ///// FraudAutoDetection Class.
//    ///// </summary>
//    //public class FraudAutoDetection
//    //{
//    //    private ITaskManager taskManager;

//    //    /// <summary>
//    //    /// Loading all tasks for scanning suspicious tickets.
//    //    /// </summary>
//    //    public FraudAutoDetection()
//    //    {
//    //        taskManager = new TaskManager();
//    //    }

//    //    /// <summary>
//    //    /// The API to add new Task to the queue for scanning.
//    //    /// </summary>
//    //    /// <param name="newTask">The new task.</param>
//    //    /// <returns>True if success.</returns>
//    //    public bool AddNewTask(Task newTask)
//    //    {
//    //        var sender = SendingTaskFactory.GetSender(SendingType.AddingTask);
//    //        return sender.Send(newTask);
//    //    }

//    //    public bool UpdateTask(Task task)
//    //    {
//    //        var sender = SendingTaskFactory.GetSender(SendingType.UpdatingTask);
//    //        return sender.Send(task);
//    //    }

//    //    public bool RemoveTask(Task task)
//    //    {
//    //        var sender = SendingTaskFactory.GetSender(SendingType.RemovingTask);
//    //        return sender.Send(task);
//    //    }

//        //public void Stop()
//        //{
//        //    try
//        //    {
//        //        _threadPool.StopAllTasks();
//        //        _messageQueue.ReceiveCompleted -= Mq_ReceiveCompleted;
//        //        _messageQueue.Stop();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}
//    }
//}