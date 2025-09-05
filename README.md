# ✨ Beautify Console

Make your data human-friendly—right from the terminal.

**Beautify Console** is a lightweight CLI tool that transforms raw JSON, XML, or delimited strings into clean, indented, readable formats. Whether you're piping from another command or grabbing from your clipboard, this tool makes beautifying effortless.

---

## 🚀 Features

- 📥 **Flexible Input**  
  Accepts data from `Console.In` (pipe) or directly from your clipboard using the `--clip` option.

- 🧠 **Smart Format Detection**  
  Automatically detects and beautifies JSON, XML, or delimited strings (CSV, TSV, etc.).

- 🧹 **Clean, Indented Output**  
  Ideal for debugging, documentation, or just making your data easier on the eyes.

- ⚡ **Fast & Minimal**  
  No GUI, no dependencies—just one executable that gets the job done.

---

## 🛠️ Usage

```bash
type data.json | beautify

beautify --clip

curl https://api.example.com/data | beautify
```

📦 Installation
Download the executable and add it to your system PATH. No external dependencies required.