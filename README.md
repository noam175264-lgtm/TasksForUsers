


> Written with [StackEdit](https://stackedit.io/).
> ## **מערכת ניהול משימות לצוות**

### תיאור הפרויקט

מערכת לניהול משימות של צוות עובדים קטן. באמצעות המערכת ניתן ליצור פרויקטים, להקצות משימות לחברי צוות, ולעקוב אחר התקדמות העבודה.

----------

### ישויות

1.  **משתמשים** (Users)
2.  **פרויקטים** (Projects)
3.  **משימות** (Tasks)

----------

## מיפוי Routes

### **משתמשים (Users)**

פעולה

Method

Route

שליפת רשימת משתמשים

`GET`

`https://taskmanager.co.il/users`

שליפת משתמש לפי מזהה

`GET`

`https://taskmanager.co.il/users/1`

הוספת משתמש

`POST`

`https://taskmanager.co.il/users`

עדכון משתמש

`PUT`

`https://taskmanager.co.il/users/1`

מחיקת משתמש

`DELETE`

`https://taskmanager.co.il/users/1`

----------

### **פרויקטים (Projects)**

פעולה

Method

Route

שליפת רשימת פרויקטים

`GET`

`https://taskmanager.co.il/projects`

שליפת פרויקט לפי מזהה

`GET`

`https://taskmanager.co.il/projects/1`

הוספת פרויקט

`POST`

`https://taskmanager.co.il/projects`

עדכון פרויקט

`PUT`

`https://taskmanager.co.il/projects/1`

מחיקת פרויקט

`DELETE`

`https://taskmanager.co.il/projects/1`

----------

### **משימות (Tasks)**

פעולה

Method

Route

שליפת רשימת משימות

`GET`

`https://taskmanager.co.il/tasks`

שליפת משימה לפי מזהה

`GET`

`https://taskmanager.co.il/tasks/1`

הוספת משימה

`POST`

`https://taskmanager.co.il/tasks`

עדכון משימה

`PUT`

`https://taskmanager.co.il/tasks/1`

מחיקת משימה

`DELETE`

`https://taskmanager.co.il/tasks/1`

----------

## פעולות נוספות

### **עדכון סטטוס משימה**

`PUT https://taskmanager.co.il/tasks/1/status` (לשנות סטטוס: ממתין → בביצוע → הושלם)

### **שליפת משימות של משתמש מסוים**

`GET https://taskmanager.co.il/users/1/tasks`

### **שליפת משימות של פרויקט מסוים**

`GET https://taskmanager.co.il/projects/1/tasks`
