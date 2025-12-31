const fs = require("fs");
const path = require("path");

// Запись
function writeFile(file, data) {
  fs.writeFileSync(file, data, "utf8");
}

// Чтение
function readFile(file) {
  return fs.readFileSync(file, "utf8");
}

// Изменение
function updateFile(file, data) {
  fs.writeFileSync(file, data, "utf8");
}

// Удаление информации
function clearFile(file) {
  fs.writeFileSync(file, "", "utf8");
}

// Удаление шума
function cleanFile(file) {
  let content = fs.readFileSync(file, "utf8");
  content = content.replace(/[0-9]/g, "").toLowerCase();
  fs.writeFileSync(file, content, "utf8");
}

// Копирование
function copyFile(src, dest) {
  fs.copyFileSync(src, dest);
}

// Создание папки
function createDir(dir) {
  if (!fs.existsSync(dir)) fs.mkdirSync(dir);
}

// Удаление папки
function removeDir(dir) {
  if (fs.existsSync(dir)) fs.rmdirSync(dir);
}

// Пути ко всем файлам
function listFiles(dir) {
  return fs.readdirSync(dir).filter(f => !["node_modules", ".git"].includes(f));
}

// Удаление всех файлов/папок кроме служебных
function cleanProject(dir) {
  listFiles(dir).forEach(f => {
    const fullPath = path.join(dir, f);
    if (fs.lstatSync(fullPath).isDirectory()) {
      fs.rmdirSync(fullPath, { recursive: true });
    } else {
      fs.unlinkSync(fullPath);
    }
  });
}

module.exports = { writeFile, readFile, updateFile, clearFile, cleanFile, copyFile, createDir, removeDir, listFiles, cleanProject };