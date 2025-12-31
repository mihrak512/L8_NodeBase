const sortStrings = require("./modules/sort");
const loadData = require("./modules/fetch");
const fsOps = require("./modules/fsModule");

async function main() {
  const users = await loadData("https://jsonplaceholder.typicode.com/users");

  const names = users.data.map(u => u.name);
  const emails = users.data.map(u => u.email);

  const sortedNames = sortStrings(names);

  fsOps.createDir("users");
  fsOps.writeFile("users/names.txt", sortedNames.join("\n"));
  fsOps.writeFile("users/emails.txt", emails.join("\n"));

  console.log("Файлы успешно созданы!");
}

main();