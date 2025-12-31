const axios = require("axios");

async function loadData(url) {
  let result = { data: [], isLoading: true, error: null };
  try {
    const res = await axios.get(url);
    result.data = res.data;
    result.isLoading = false;
  } catch (err) {
    result.error = err.message;
    result.isLoading = false;
  }
  return result;
}

module.exports = loadData;