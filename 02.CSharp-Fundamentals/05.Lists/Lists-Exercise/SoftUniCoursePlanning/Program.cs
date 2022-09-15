using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialCoursesList = Console.ReadLine().Split(", ").ToList();
            string[] input = Console.ReadLine().Split(":").ToArray();

            while (input[0] != "course start")
            {
                string[] commandLine = input;
                string commandPrefix = commandLine[0];

                switch (commandPrefix)
                {
                    case "Add":
                        string commandToken = commandLine[1];
                        bool isLessonPresent = DoesLessonExist(initialCoursesList, commandToken);
                        if (!isLessonPresent)
                        {
                            initialCoursesList.Add(commandToken);
                        }
                        break;
                    case "Insert":
                        commandToken = commandLine[1];
                        int commandIndex = int.Parse(commandLine[2]);
                        isLessonPresent = DoesLessonExist(initialCoursesList, commandToken);
                        if (!isLessonPresent)
                        {
                            initialCoursesList.Insert(commandIndex, commandToken);
                        }
                        break;
                    case "Remove":
                        commandToken = commandLine[1];
                        isLessonPresent = DoesLessonExist(initialCoursesList, commandToken);
                        if (isLessonPresent)
                        {
                            initialCoursesList.Remove(commandToken);
                        }

                        string exerciseName = commandToken + "-Exercise";
                        bool isExercisePresent = DoesLessonExist(initialCoursesList, exerciseName);
                        if (isExercisePresent)
                        {
                            initialCoursesList.Remove(exerciseName);
                        }
                        break;
                    case "Swap":
                        commandToken = commandLine[1];
                        string commandTokenTwo = commandLine[2];
                        isLessonPresent = DoesLessonExist(initialCoursesList, commandToken);
                        bool isLessonPresentTwo = DoesLessonExist(initialCoursesList, commandTokenTwo);

                        if (isLessonPresent && isLessonPresentTwo)
                        {
                            SwapIndices(initialCoursesList, commandToken, commandTokenTwo);
                        }

                        string exerciseNameOne = commandToken + "-Exercise";
                        string exerciseNameTwo = commandTokenTwo + "-Exercise";
                        isExercisePresent = DoesLessonExist(initialCoursesList, exerciseNameOne);
                        bool isExercisePresentTwo = DoesLessonExist(initialCoursesList, exerciseNameTwo);
                        if (isExercisePresent && isExercisePresentTwo)
                        {
                            SwapIndices(initialCoursesList, exerciseNameOne, exerciseNameTwo);
                        }
                        else if (!isExercisePresent && isExercisePresentTwo)
                        {
                            int previousLesson = GetLessonIndex(initialCoursesList, commandTokenTwo);
                            previousLesson += 1;
                            initialCoursesList.RemoveAt(initialCoursesList.IndexOf(exerciseNameTwo));
                            initialCoursesList.Insert(previousLesson, exerciseNameTwo);
                        }
                        else if (isExercisePresent && !isExercisePresentTwo)
                        {
                            int previousLesson = GetLessonIndex(initialCoursesList, commandToken);
                            previousLesson += 1;
                            initialCoursesList.RemoveAt(initialCoursesList.IndexOf(exerciseNameOne));
                            initialCoursesList.Insert(previousLesson, exerciseNameOne);
                        }
                        break;
                    case "Exercise":
                        commandToken = commandLine[1];
                        isLessonPresent = DoesLessonExist(initialCoursesList, commandToken);
                        exerciseName = commandToken + "-Exercise";
                        isExercisePresent = DoesLessonExist(initialCoursesList, exerciseName);

                        if (isLessonPresent && !isExercisePresent)
                        {
                            int lessonIndex = GetLessonIndex(initialCoursesList, commandToken);
                            initialCoursesList.Insert(lessonIndex + 1, exerciseName);
                        }
                        else if (!isLessonPresent)
                        {
                            initialCoursesList.Add(commandToken);
                            initialCoursesList.Add(exerciseName);
                        }
                        break;
                }

                input = Console.ReadLine().Split(":").ToArray();
            }

            foreach (string course in initialCoursesList)
            {
                Console.WriteLine($"{initialCoursesList.IndexOf(course) + 1}.{course}");
            }
        }

        static bool DoesLessonExist(List<string> courseList, string searchSpecificCourse)
        {
            bool isPresent = false;

            int indexOfCourse = courseList.IndexOf(courseList.Find(item => item == searchSpecificCourse));

            if (indexOfCourse >= 0)
            {
                isPresent = true;
            }

            return isPresent;
        }

        static void SwapIndices(List<string> courseList, string courseOne, string courseTwo)
        {
            int indexOfCourseOne = courseList.IndexOf(courseList.Find(item => item == courseOne));
            int indexOfCourseTwo = courseList.IndexOf(courseList.Find(item => item == courseTwo));

            string temp = courseList[indexOfCourseOne];
            courseList[indexOfCourseOne] = courseList[indexOfCourseTwo];
            courseList[indexOfCourseTwo] = temp;

        }
        static bool DoesExerciseExist(List<string> courseList, string searchSpecificExercise)
        {
            bool isPresent = false;

            int indexOfCourse = courseList.IndexOf(courseList.Find(item => item == searchSpecificExercise));

            if (indexOfCourse >= 0)
            {
                isPresent = true;
            }

            return isPresent;
        }

        static int GetLessonIndex(List<string> courseList, string searchSpecificCourse)
        {
            int lessonIndex = -1;

            lessonIndex = courseList.IndexOf(courseList.Find(item => item == searchSpecificCourse));

            return lessonIndex;
        }
    }
}
