# 📘 [ASOIU Seminar 2 — Sparse Matrix Formats](https://github.com/ugapanyuk/course-architecture/blob/main/seminars/seminar2.pdf)

## 📌 Описание проекта

В рамках семинара №2 реализованы основные форматы хранения разреженных матриц:

- COO (Coordinate Format)
- LIL (List of Lists)
- CSR (Compressed Sparse Row)

Для каждого формата реализовано:
- преобразование из плотной матрицы (Dense → Sparse)
- восстановление обратно (Sparse → Dense)
- проверка эффективности хранения
- тестирование на примерах из методички

---

## 🧠 Реализованные форматы

### 1. COO (Coordinate)
Хранит:
- массив строк Row
- массив столбцов Column
- массив значений Data

Память: 3N

---

### 2. LIL (List of Lists)
Хранит:
- для каждой строки список столбцов
- для каждой строки список значений

Память: 2N

---

### 3. CSR (Compressed Sparse Row)
Хранит:
- Data — значения
- Indices — столбцы
- IndexPointers — границы строк

Память: 2N + R + 1

---

## 📁 Структура проекта
``` bash
ASOIU_sem2/
├── Seminar2/
│   └── Program.cs
├── Seminar2_ver2/
│   ├── Program.cs
│   ├── Helpers.cs
│   ├── CooFormat.cs
│   ├── LilFormat.cs
│   ├── CsrFormat.cs
```

---

## 🔹 Версия 1 — Seminar2

Запуск:

``` bash
cd Seminar2
dotnet run
```
---

## 🔹 Версия 2 — Seminar2_ver2

Запуск:
``` bash
cd Seminar2_ver2
dotnet run
```
---

## 📊 Что делает программа

1. Выводит исходную матрицу
2. Считает ненулевые элементы
3. Проверяет эффективность
4. Выполняет преобразование
5. Восстанавливает матрицу
6. Проверяет корректность

---

## 🛠 Используемые технологии

- C#
- .NET
- VS Code
- Git

---

# 👨‍💻 Автор
Григорий Корнеев ИУ5-24Б

[Репозиторий курса АСОИУ](https://github.com/gregkorneev-BMSTU/ASOIU)
