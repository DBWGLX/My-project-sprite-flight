# 火箭穿越行星带

Unity2D | C# | 个人扩展开发

[在线体验](https://play.unity.com/en/games/5dd45b98-7cd8-47f9-b920-31b2b81916ad/spriteflightdbwglx)

<img width="725" height="386" alt="image" src="https://github.com/user-attachments/assets/85db8e9c-97b9-4780-9136-74c07b73313f" />

<img width="725" height="386" alt="image" src="https://github.com/user-attachments/assets/6a92c0c9-1162-4055-b9c9-2f1fed2aa277" />

<img width="725" height="386" alt="image" src="https://github.com/user-attachments/assets/599c1402-0ca4-468d-8915-6f93fc765e02" />


## 项目简介：
玩家操作小火箭躲避障碍物。

- 基于 Unity 官方 Sprite Flight 扩展开发，独立完成开始菜单、游戏状态机、
  难度递增（每秒生成障碍物）等模块。
- 基于 Rigidbody2D 实现无重力太空移动，方向向量 + 推力控制飞行手感。
- 使用对象池管理障碍物与碰撞粒子，避免频繁 Instantiate/Destroy 造成 GC 峰值。
- 使用 Particle System 实现碰撞爆炸与滚动星空背景。
- 实现 Ready / Playing / GameOver 状态机，碰撞后停止输入并弹出重开 UI。

