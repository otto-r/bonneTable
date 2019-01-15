import axios from "axios";

let baseUrl = "https://localhost:44383/api/table/";

export async function getToken(userInfo) {
  try {
    const response = await axios({
      method: "post",
      url: baseUrl + "authenticate",
      data: userInfo
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}
