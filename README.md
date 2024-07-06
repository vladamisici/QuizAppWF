## Utilizare

### Formatul JSON pentru intrebari
Fisierul JSON este cautat in directorul curent si trebuie sa aiba numele "quiz.json" (QuizForm.cs / LoadQuestions())
Intrebările trebuie scrise intr-un fisier JSON in urmatorul format:
```json
[
 {
     "QuestionText": "Care este capitala Franței?",
     "Options": ["Paris", "Londra", "Berlin", "Madrid"],
     "CorrectAnswer": "Paris",
     "Points": 25
 },
 {
     "QuestionText": "Cine a scris 'Hamlet'?",
     "Options": ["Charles Dickens", "J.K. Rowling", "William Shakespeare", "Mark Twain"],
     "CorrectAnswer": "William Shakespeare",
     "Points": 25
 },
 {
     "QuestionText": "Care este simbolul chimic pentru apă?",
     "Options": ["H2O", "CO2", "O2", "N2"],
     "CorrectAnswer": "H2O",
     "Points": 50
 }
]
```
### Salvare rezultate
Rezultatele se salveaza intr-un folder creat la finalul quiz-ului in directorul curent ( /{nume_user}_results/{nume_user}_results_{dd_mm_yy_hh_min_sec}.xlsx

(Se poate modifica asta din QuizForm.cs / SaveResults() in variabila folderPath (string folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"{username}_results");) )


### OBS. 
Datele de intrare sunt considerate corecte, nu am luat in vedere erori ale utilizatorului (ex. intrebarile nu acumuleaza 100 puncte in total, numele utilizatorului are caractere speciale si apar erori la salvarea fisierului excel cu rezultatele etc.)

Foloseste biblioteca EPPlus pentru lucrul cu fisierele Excel
