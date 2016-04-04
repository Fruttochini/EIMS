# EIMS
EIMS - Educational Institution Management System.

ASP.NET MVC final project for IT STEP academy, Kiev, Ukraine.

Requirements: .NET Framework 4.5.2, MS SQL Server 2012 (Express edition), Google Chrome (was tested on this browser)

Provides next possibilities by roles:
Admin:
 - Users management: create/edit/delete;
 - Faculties management: create, edit;
 - Groups management: create group assigned to specific faculty, edit, delete, assign students to groups, create group schedule, assign studing course;
 - Subjects: create/edit/delete, assign specific requirements;
 - Rooms: create/edit/delete, assign specific possibilities (corresponds to subject requirements);
 - Courses: create/edit/delete, include subjects and subject hours per week to corresponding course;
 - Teachers: assign subjects;

Teacher:
 - Has personal schedule according to groups schedule;
 - Can input student pressence, marks and home tasks;

Student:
 - Has personal (group) schedule;
 - Can read home task list;
