﻿(function (a) {
	a.fn.SharkDevTreeView = function (c) {
		var d = new function (g) {
			this.AfterSelectHandler = c.AfterSelectHandler;
			this.DataOnClient = c.DataOnClient;
			this.AutoCompleteHandler = c.AutoCompleteHandler;
			this.ControlId = g
		}
		(this.attr("id"));
		var f = d.ControlId + "_rootUl";
		var e = "hiddenUl";
		var b = "Expander_0";
		ProgressBar = function (n) {
			var h = 1;
			var k = "progressCell";
			var g = false;
			var m = a("#" + n + " #progressParent")[0];
			var l = a("#" + n + " #progressParent > span");
			var j;
			this.Start = function () {
				a(m).css("display", "inline");
				var i = this;
				j = setInterval(function () {
						i.Loop()
					}, 300)
			};
			this.Loop = function () {
				if (h > 3) {
					this.ResetControls();
					h = 1
				} else {
					this.ResetControls();
					a(l).each(function (o, i) {
						var p = k + h;
						if (i.id == p) {
							a(i).css("padding-top", "2px");
							a(i).css("padding-bottom", "2px");
							a(i).css("padding-left", "2px");
							return false
						}
					});
					++h
				}
			};
			this.Stop = function () {
				a(m).css("display", "");
				h = 1;
				g = false;
				this.ResetControls();
				clearInterval(j)
			};
			this.ResetControls = function () {
				a(l).css("padding-top", "0px");
				a(l).css("padding-bottom", "0px");
				a(l).css("padding-left", "0px")
			}
		};
		ScrollToElement = function (k, j) {
			a("#" + j.ControlId + "_rootUl").removeClass("hiddenUl");
			var p = a("#" + j.ControlId + " #Content_" + k).parents("li");
			for (var l = 0; l < p.length; l++) {
				a(p[l]).removeClass(e).removeClass("contentSelected")
			}
			var h = p[0];
			for (var l = 0; ; l++) {
				h = a(h).parent().closest("li").get(0);
				var m = a(h).find("a");
				if (m.length > 0) {
					a(m[0]).removeClass("expand");
					a(m[0]).addClass("collapse")
				}
				if (h == undefined) {
					break
				}
			}
			var n = j.ControlId + "_header";
			var g = a("#" + n).offset().top + 20;
			var o = j.ControlId + "_tree";
			a("#" + o).animate({
				scrollTop: 0,
				scrollLeft: 0
			}, 0, function () {
				if (a("#" + j.ControlId + " #Content_" + k).get(0) != undefined) {
					var r = a("#" + j.ControlId + " #Content_" + k).offset().top;
					var q = a("#" + j.ControlId + " #Content_" + k).offset().left;
					var i = a("#" + j.ControlId + " #Content_" + k).offset().right;
					a("#" + o).animate({
						scrollTop: r - g,
						scrollRight: i
					}, 200, function () {
						SelectElement(a("#" + j.ControlId + " #Content_" + k), j)
					})
				}
			})
		};
		SelectElement = function (h, i) {
			if (a("#" + i.ControlId + ' a[id="Expander_0"]').hasClass("expand")) {
				a("#" + i.ControlId + ' a[id="Expander_0"]').removeClass("expand");
				a("#" + i.ControlId + ' a[id="Expander_0"]').addClass("collapse")
			}
			var g = a(h).attr("obj");
			a("#" + i.ControlId + " span[class=contentSelected]").parent().removeClass("hover2");
			a("#" + i.ControlId + " span[class=contentSelected]").removeClass("contentSelected");
			var k = a(h).text();
			a(h).text("");
			a(h).addClass("hover2");
			a(h).append('<span id="contentInside" class="contentSelected">' + k + "</span>");
			var j = a(h).prev('a[id^="Expander"]');
			if (i.AfterSelectHandler != null) {
				i.AfterSelectHandler(JSON.parse(g))
			}
		};
		BindMethods = function () {
			return function (h, g) {
				var j;
				a("#" + g.ControlId + "_autoCompleteInput").autocomplete({
					source: function (l, k) {
						if (g.DataOnClient) {
							var m = JSON.parse(a("#" + g.ControlId + "_JsonData").text());
							k(a.map(m, function (n) {
									if (n.Term.toLowerCase().indexOf(l.term.toLowerCase()) == 0) {
										return {
											label: n.Term,
											id: n.Id
										}
									}
								}))
						} else {
							a.ajax({
								type: "POST",
								url: g.AutoCompleteHandler + "?q=" + l.term,
								dataType: "json",
								contentType: "application/json; charset=utf-8",
								success: function (n) {
									var o = n;
									k(a.map(o, function (p) {
											return {
												label: p.Term,
												id: p.Id
											}
										}))
								}
							})
						}
					},
					appendTo: a("#" + g.ControlId + "_autoCompleteInput").parent(),
					minLength: 2,
					messages: {
						noResults: "",
						results: function (k, l) {}
					},
					response: function (k, l) {
						j.Stop();
						j = null
					},
					search: function (k, l) {
						j = new ProgressBar(g.ControlId);
						j.Start()
					},
					select: function (k, l) {
						ScrollToElement(l.item.id, g)
					}
				});
				var i = a("#" + h + ' span[id^="Content"]');
				a(i).mouseover(function () {
					a(this).addClass("hover")
				});
				a(i).mouseleave(function () {
					a(this).removeClass("hover")
				});
				a(i).click(function () {
					SelectElement(this, g)
				});
				a("#" + h + ' a[id^="Expander"]').click(function (l) {
					var k = a(this).parents("li").get(0);
					if (a(k).hasClass(e) == true) {
						a(k).removeClass(e)
					} else {
						a(k).addClass(e)
					}
					if (a(this).hasClass("expand")) {
						a(this).removeClass("collapse");
						a(this).removeClass("expand");
						a(this).addClass("collapse")
					} else {
						a(this).removeClass("collapse");
						a(this).removeClass("expand");
						a(this).attr("class", "");
						a(this).addClass("expand")
					}
				});
				a("#" + g.ControlId + ' a[id="Expander_0"]').off("click");
				a("#" + g.ControlId + ' a[id^="Expander_0"]').click(function (k) {
					if (a("#" + f).hasClass(e) == true) {
						a("#" + f).removeClass(e);
						a(this).attr("class", "");
						a(this).addClass("collapse")
					} else {
						a(this).attr("class", "");
						a(this).addClass("expand");
						a("#" + f).addClass(e)
					}
				})
			}
			(f, d)
		}
		()
	}
})(jQuery);
