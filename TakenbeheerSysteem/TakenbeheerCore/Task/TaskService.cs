﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using TakenbeheerCore.SubTask;
using TakenbeheerDAL.Task;

namespace TakenbeheerCore.Task
{
    public class TaskService
    {
        private ITaskRepository _taskRepository;
        
        public TaskService(ITaskRepository repo) 
        {
            _taskRepository = repo;
        }

        public List<Task> ReturnAllTasks()
        {
            List<Task> tasks = new List<Task>();

            List<TaskDTO> tasksDTO = _taskRepository.ReturnAllTasks();

            foreach (TaskDTO taskDTO in tasksDTO)
            {
                Task entry = new Task(
                    taskDTO.Id,
                    taskDTO.Title,
                    taskDTO.Description,
                    taskDTO.Progress,
                    taskDTO.Deadline,
                    taskDTO.IsVisible
                    );
                tasks.Add(entry);
            }

            return tasks;
        }

        public List<Subtask> GetSubtasks(int id)
        {
            List<Subtask> subtasks = new List<Subtask>();

            return subtasks;
        }

        public List<WorkerEmployee> GetWorkers(int id)
        {
            List<WorkerEmployee> workers = new List<WorkerEmployee>();

            return workers;
        }


    }
}