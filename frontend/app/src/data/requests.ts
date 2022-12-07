import "jquery";
import { httpAjaxRequest } from "../services/http";
import Konva from "konva";
import "kendo-ui-core";
import Dot from "../models/dot";
import { findBgColor, findDotColor } from "./colorFunc";

const stage = new Konva.Stage({
  container: "container",
  width: screen.width,
  height: screen.height,
});
const layer = new Konva.Layer();

// получаем все данные из базы
export const getAllInform = (): void => {
  const request = httpAjaxRequest({
    path: `/dots`,
    method: "GET",
  });
  // если данные получены
  request.done(function (response: Array<Dot>) {
    // проходим по всем точкам в ответе
    response.forEach((dotVal, ind1) => {
      // создаем точку с параметрами из базы данных
      const circle = new Konva.Circle({
        id: dotVal.dotId.toString(),
        x: dotVal.xpos,
        y: dotVal.ypos,
        radius: dotVal.radius,
        fill: findDotColor(dotVal.color),
        stroke: "black",
        strokeWidth: 3,
      });
      layer.add(circle);
      stage.add(layer);

      // событие уничтожение точек и их комментариев при двойном нажатиии
      circle.on("dblclick", function () {
        deleteDot(Number(circle.attrs.id));
        const wrapper = document.getElementById("comWrap" + circle.attrs.id);
        wrapper?.remove();
        circle.destroy();
      });

      // обертка над комментариями
      const commentWrapper = document.createElement("div");
      commentWrapper.style.left = dotVal.xpos - 200 + "px";
      commentWrapper.style.top = dotVal.ypos + dotVal.radius + 10 + "px";
      commentWrapper.setAttribute("id", "comWrap" + dotVal.dotId);

      // проходим через все комментарии в модели точки
      dotVal.comments.forEach((comVal, ind) => {
        const textbox = document.createElement("input");
        textbox.setAttribute("id", "box" + comVal.commentId);
        $(textbox).kendoTextBox({
          value: comVal.text,
          readonly: true,
          size: "none",
        });

        // добавляем свойство цвета в завимости от полученных данных из базы
        $(textbox).addClass(findBgColor(comVal.backgroundColor));
        $(commentWrapper).addClass("wrapper");
        commentWrapper.appendChild(textbox);
      });
      $("#container").append(commentWrapper);
    });
  });
  request.fail(function (restponse, mes) {
    alert("Данные не найдены: " + mes);
  });
};

// удаление точки и ее комментариев из базы данных
export const deleteDot = (dotId: number): void => {
  const request = httpAjaxRequest({
    path: `/dots/${dotId}`,
    method: "DELETE",
  });
  request.done(function (response: JQuery.jqXHR) {
    alert("Succuess");
  });
  request.fail(function (response: JQuery.jqXHR, mes) {
    alert("Request failed: " + mes);
  });
};
