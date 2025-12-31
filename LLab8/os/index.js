const os = require("os");
require("dotenv").config();

// a) Основная информация
function systemInfo() {
  console.log("Платформа:", os.platform());
  console.log("Свободная память:", os.freemem() / 1024 / 1024, "MB");
  console.log("Главная директория:", os.homedir());
  console.log("Имя пользователя:", os.userInfo().username);
  console.log("Сеть:", os.networkInterfaces());
}

// b) Проверка памяти > 4GB
function checkMemory() {
  const freeGB = os.freemem() / 1024 / 1024 / 1024;
  return freeGB > 4 ? "Памяти достаточно" : "Мало памяти";
}

// c) Доступ по MODE
function accessSystemInfo() {
  if (process.env.MODE === "admin") {
    systemInfo();
  } else {
    console.log("Недостаточно прав для просмотра информации");
  }
}

module.exports = { systemInfo, checkMemory, accessSystemInfo };