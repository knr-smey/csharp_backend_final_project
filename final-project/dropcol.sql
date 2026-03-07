-- ===============================
-- REMOVE UserId FROM SUBCATEGORIES
-- ===============================

ALTER TABLE subcategories 
DROP FOREIGN KEY FK_SubCategories_Users_UserId;

ALTER TABLE subcategories 
DROP INDEX IX_SubCategories_UserId;

ALTER TABLE subcategories 
DROP COLUMN UserId;


-- ===============================
-- REMOVE UserId FROM CATEGORIES
-- ===============================

ALTER TABLE categories 
DROP FOREIGN KEY FK_Categories_Users_UserId;

ALTER TABLE categories 
DROP INDEX IX_Categories_UserId;

ALTER TABLE categories 
DROP COLUMN UserId;


-- ===============================
-- REMOVE UserId FROM COURSES
-- ===============================

ALTER TABLE courses 
DROP FOREIGN KEY FK_Courses_Users_UserId;

ALTER TABLE courses 
DROP INDEX IX_Courses_UserId;

ALTER TABLE courses 
DROP COLUMN UserId;