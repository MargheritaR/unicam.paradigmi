# unicam.paradigmi
Progetto Unicam Paradigmi Avanzati di programmazione Enterprise

+ Progetto n.1 : Realizzazione di una web api che permetta la gestione di un catalogo di una libreria.

# Esecuzione Progetto

## Creazione Database

Creare il database utilizzando il dump che sta nella cartella Database

Utente admin database

- user :  AdParadigmi
- password:  AdParadigmi 

## Esecuzione
Eseguire il progetto UnicamParadigmi.Web da cui partirà Swagger

## Registrazione e Login
Registrarsi utilizzando una mail non utilizzata e una password che deve essere lunga almeno 6 caratteri, contenere almeno un carattere maiuscolo,una minuscola, un numero e un carattere speciale

Per il Login inserire email e password e si otterà il token jwt che è necessario per effettuare tutte le chiamate

## Altre chiamate

Libro:

- New : chiamata per l'inserimento di un libro
- Edit : chiamata per la modifica di un libro
- Delete : chiamata per la rimozione di un libro
- Ricerca : Ricerca di un libro per editore, nome, categoria e data di pubblicazione

La ricerca paginerà i risultati in base ai parametri passanti nella chiamata, verrà visualizzato i libri e il numero delle pagine

Categorie:

- New : chiamata per l'inserimento di una categoria
- Delete : chiamata per la rimozione di una categoria

Utente:
- NewUtente : chiamata per creare un nuovo utente senza autenticazione
