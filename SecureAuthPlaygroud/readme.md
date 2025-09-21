# SecureAuth Playground

Passwords are like **keys to your digital life**. This project demonstrates how to keep them safe. I built a system that stores passwords in **secure “digital safes”** using industry-standard algorithms like **Bcrypt** and **Argon2**. I also created a simple **toy hasher** to show why weak hashing methods fail. Even if someone steals the database, properly hashed passwords remain practically impossible to crack.

https://www.youtube.com/watch?v=wEkhclIvtoo

This is a **C# console app** that lets you register users, login, and see firsthand how secure password handling works, plus it comes with **automated xUnit tests** to cover edge cases.

---

## Features

* **Secure Hashing Algorithms**

  * **Bcrypt** – widely used, reliable
  * **Argon2** – memory-hard and very secure
* **Educational Toy Hasher**

  * Shows what happens when passwords are stored insecurely
* **Interactive Console**

  * Register new users
  * Login with password masking (asterisks)
  * Pick which hashing algorithm to use at runtime
  * Get colored feedback for success or failure
* **Automated xUnit Tests**

  * Check registration and login edge cases
  * Compare secure vs insecure hashing

---

## How It Works

1. When you start the app, you **choose which hashing algorithm** to use (Bcrypt, Argon2, or the Toy Hasher).
2. **Register a user:** Enter a username and password. The password gets hashed with a **salt** and a **pepper** before being stored.
3. **Login:** Enter your credentials. The system checks your password against the stored hash.

   * Using the Toy Hasher quickly demonstrates why weak hashes are dangerous.
4. **Database Simulation:** All user data is stored in a simple in-memory database for demo purposes.

---

## Why I Built This

* To **demonstrate real-world security practices** in a way anyone can understand.
* To **teach why weak hashing fails** in an interactive, hands-on way.
* To have a **demo that’s recruiter-friendly**, easy to run, and visually clear with success/fail feedback.

---

## Getting Started

1. Clone this repository:

```bash
git clone <your-repo-url>
```

2. Open the solution in **Visual Studio** or **VS Code**.

3. Run the console app:

   * Pick a hashing algorithm
   * Register a user
   * Login with the credentials
   * Watch the secure hashing in action

4. Run the **xUnit tests** to see all edge cases automatically verified.

---

## Tech Stack

* **C# .NET 8**
* **xUnit** for unit testing
* **Bcrypt.Net-Next** (Bcrypt hashing)
* **Isopoh.Cryptography.Argon2** (Argon2 hashing)

---

## Key Takeaways

* Never store passwords in plain text.
* Use strong hashing algorithms with salts (and optionally peppers) to protect user data.
* Weak hashing is educational only, never use it in production.
* Interactive demos like this make security concepts easy to understand for anyone.

---
