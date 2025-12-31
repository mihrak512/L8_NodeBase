const bcrypt = require("bcrypt");

const passwords = Array.from({ length: 13 }, (_, i) => `password${i+1}`);

async function hashPasswords() {
  for (let pwd of passwords) {
    const start = Date.now();
    await bcrypt.hash(pwd, 10);
    const end = Date.now();
    console.log(`Пароль ${pwd} зашифрован за ${end - start} мс`);
  }
  console.log("Разное время связано с нагрузкой CPU и случайностью соли");
}

hashPasswords();