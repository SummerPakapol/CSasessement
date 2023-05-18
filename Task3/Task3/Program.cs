
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Task3
{
	class Job
	{
		public string Name { get; set; }
		public int Duration { get; set; }
	}
	class JobQueue
	{
		private Queue<Job> _queue = new Queue<Job>();
		private object _lock = new object();

		public void Enqueue(Job job)
		{
			lock (_lock)
			{
				_queue.Enqueue(job);
			}
		}
		public Job Dequeue()
		{
			lock (_lock)
			{
				if (_queue.Count == 0) return null;
				return _queue.Dequeue();
			}
		}
	}

	class Worker
	{
		private JobQueue _jobQueue;
		private string _outputFile;

		public Worker(JobQueue jobQueue, string outputFile)
		{
			_jobQueue = jobQueue;
			_outputFile = outputFile;
		}

		public void Work()
		{
			while (true)
			{
				Job job = _jobQueue.Dequeue();
				if (job == null) break;
				string result = ProcessJob(job);
				WriteResult(result);
				
			}
		}

		private string ProcessJob(Job job)
		{
			System.Console.WriteLine("$Processing Job {job.Name}");
			Thread.Sleep(job.Duration);
			return $"{job.Name}:{job.Duration}ms";
		}

		private void WriteResult(string result)
		{
			//lock (_outputFile)
			//{
			object _locking = new object();
			lock (_locking)
			{
				using (StreamWriter writer = new StreamWriter(_outputFile, true))
				{

					writer.WriteLine(result);

				}
			}
			//}
		}
	}

	class debugging
	{
		static void Main()
		{
			JobQueue jobQueue = new JobQueue();
			jobQueue.Enqueue(new Job { Name = "Job1", Duration = 1000 });
			jobQueue.Enqueue(new Job { Name = "Job2", Duration = 500 });
			jobQueue.Enqueue(new Job { Name = "Job3", Duration = 2000 });
			jobQueue.Enqueue(new Job { Name = "Job4", Duration = 750 });
			jobQueue.Enqueue(new Job { Name = "Job5", Duration = 1500 });



			//List<Worker> workers = new List<Worker>();
			for (int i = 0; i < 4; i++)
			{
				Worker worker = new Worker(jobQueue, "output.txt");
				Thread thread = new Thread(worker.Work);
				//workers.Add(worker);
				thread.Start();
			}

			/*foreach (Worker worker in workers)
			{
				worker.Work();
			}
			*/
			System.Console.WriteLine("all jobs done");
		}
	}
}

