import { webApiUrl } from "./appSettings";
import $ from 'jquery';

export interface HttpRequest<REQB> {
    path: string;
    method?: string;
    body?: REQB;
  }
  export const httpAjaxRequest = <REQB = undefined>(
    config: HttpRequest<REQB>,
  ): JQuery.jqXHR<any> => {
    const request = $.ajax({
        url: `${webApiUrl}${config.path}`,
        method: config.method || 'GET',
        data: config.body?JSON.stringify(config.body):undefined,
        contentType: "application/json; charset=utf-8",
    });
    return request;
  };
  