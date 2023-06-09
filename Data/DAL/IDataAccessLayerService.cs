﻿using Data.Models;
using System.Diagnostics;

namespace Data.DAL
{
    public interface IDataAccessLayerService
    {
        Course AddCourse(string courseName);
        Mark AddMark(int value, int studentId, int courseId);
        Student CreateStudent(Student student);
        void DeleteStudent(int studentId);
        List<Course> GetAllCourses();
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void Seed();
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);
        Student UpdateStudent(Student studentToUpdate);
        Task<Student> GetOldestStudent();
    }
}