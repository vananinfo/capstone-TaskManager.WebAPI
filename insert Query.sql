--Create Table ParentTasks
-- (
--parent_id bigint Primary Key Identity(1,1),
--parent_task varchar(200)
-- )
-- drop table ParentTask
-- drop table Task
-- Create table Tasks
-- (
--  task_id bigint Primary Key Identity(1,1),
--  parent_id bigint references ParentTask(parent_id) ,
--  task varchar(200),
--  start_date date,
--  end_date date,
--  priority int,
--   )
   
   Select * from ParentTasks
   Insert into ParentTasks values(15,'ParentTask1')
    Insert into ParentTasks values(16,'ParentTask2')
    Insert into ParentTasks values(17,'ParentTask3')
    Insert into ParentTasks values(18,'ParentTask4')
    Insert into ParentTasks values(19,'ParentTask5')
    Insert into ParentTasks values(20,'ParentTask6')

   Select * from ParentTasks
   Select * from Tasks
   Insert into Tasks values(1,'ParentTask1_subtask1', GetDate()-1, GetDate()+10,1,1)
      Insert into Tasks values(2,'ParentTask1_subtask2', GetDate()-1, GetDate()+10,1,1)
      Insert into Tasks values(3,'ParentTask1_subtask3', GetDate()-1, GetDate()+10,1,1)
      Insert into Tasks values(4,'ParentTask1_subtask4', GetDate()-1, GetDate()+10,1,1)
      Insert into Tasks values(5,'ParentTask1_subtask5', GetDate()-1, GetDate()+10,1,1)
      Insert into Tasks values(6,'ParentTask1_subtask3', GetDate()-1, GetDate()+10,1,1)
      Insert into Tasks values(7,'ParentTask1_subtask7', GetDate()-1, GetDate()+10,1,1)

	  delete from dbo.Tasks
	  SELECT 
    [Extent1].[parent_id] AS [parent_id], 
    [Extent1].[parent_task] AS [parent_task]
    FROM [dbo].[ParentTasks] AS [Extent1]

	SELECT 
    [Extent1].[task_id] AS [task_id], 
    [Extent1].[parent_id] AS [parent_id], 
    [Extent1].[task] AS [task], 
    [Extent1].[start_date] AS [start_date], 
    [Extent1].[end_date] AS [end_date], 
    [Extent1].[priority] AS [priority], 
    [Extent1].[taskended] AS [taskended]
    FROM [dbo].[Tasks] AS [Extent1]

	RENAME [Task]  to  [Tasks]

exec sp_rename 'Task','Tasks'

select * from Tasks

drop table Tasks

Select 



