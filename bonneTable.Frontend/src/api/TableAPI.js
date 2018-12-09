import axios from "axios";

let baseUrl = "https://localhost:44383/api/table/";

export async function getTables() {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    console.log(response.data);
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getById(id) {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl + "?id=" + id, //?id= behövs inte
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    console.log(response.data);
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function removeTable(id) {
  try {
    const response = await axios({
      method: "delete",
      url: baseUrl + id,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    console.log(response.data);
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function addTable(tableRequest) {
  try {
    const response = await axios({
      method: "post",
      url: baseUrl,
      data: tableRequest,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function editTable(table) {
  try {
    console.log(table.seats);
    const response = await axios({
      method: "put",
      url: baseUrl + table.id,
      data: { numberOfSeats: table.seats },
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    console.log(response.data);
    return response.data;
  } catch (error) {
    console.log(error);
  }
}
