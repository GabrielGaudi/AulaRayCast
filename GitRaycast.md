---


---

<blockquote>
<p>Written with <a href="https://stackedit.io/">StackEdit</a>.</p>
</blockquote>
<h2 id="atividade-raycast-1104">Atividade Raycast 11/04</h2>
<p>Processo de Desenvolvimento:</p>
<ol>
<li>Organização e preparação<br>
Após a cena ser criada, foram adicionadas pastas para os scripts, materiais e prints para documentação dentro dos <em>Assets</em>. Na cena, foi criado um objeto contendo um <em>CharacterController</em> e a câmera para o jogador, e um plano para o chão.<br>
(imagens)</li>
<li>Scripts básicos</li>
</ol>
<ul>
<li>
<p>PlayerMovement.cs: para movimentação do jogador pelo mapa<br>
(imagem)<br>
Variáveis:</p>
<ul>
<li><strong>speed;</strong> Variável float que determina o quão rápido o jogador vai se movimentar.</li>
<li><strong>playerController;</strong> contém o componente <em>CharacterController</em> do objeto do jogador.</li>
<li><strong>movX e movZ;</strong> usadas para armazenar a entrada do jogador nas teclas de movimento (WASD e as setas).</li>
<li><strong>playerMovement;</strong> Vetor cujo valor é a junção da posição do jogador no eixo X (transform.right) com a entrada de movimento. O mesmo vale para o eixo Z (transform.forward).</li>
</ul>
<p>Métodos:</p>
<ul>
<li><strong>FixedUpdate();</strong> é usado ao invés do Update pois se mantém consistente não importa a velocidade da máquina.</li>
<li><strong>Input.GetAxis(“Horizontal”, “Vertical”)</strong> retorna certos valores quando o jogador pressiona as teclas de movimento.</li>
<li><strong>playerController.Move();</strong> move o <em>CharacterController</em> do objeto do jogador e o objeto em si, baseado na tecla apertada e a posição atual, relativamente à velocidade (variável <strong>speed</strong>).</li>
</ul>
</li>
<li>
<p>CameraControl.cs: para movimentação da câmera com o mouse e a rotação do jogador de acordo com ela.<br>
(imagem)<br>
Variáveis:</p>
<ul>
<li><strong>lookSpeed;</strong> float que controla o quão rápido a câmera vai se mover com o movimento do mouse.</li>
<li><strong>cameraVertical;</strong> subtraído do movimento do mouse, retorna um valor igual a rotação que a câmera deve sofrer.</li>
<li><strong>playerTransform;</strong> o componente <em>Transform</em> do objeto do jogador.</li>
<li><strong>mouseX, mouseY;</strong> armazenam o movimento do mouse com sua direção, proporcionalmente ao valor da velocidade.</li>
</ul>
<p>Métodos:</p>
<ul>
<li><strong>Start();</strong> ao iniciar o jogo, deixa o cursor invisível e travado no centro da tela, com <em><strong>CursorLockMode.Locked</strong></em>.</li>
<li>**Input.GetAxis(“Mouse X”, "Mouse Y); ** retorna valores baseado nos movimentos do mouse.</li>
<li><strong>Mathf.Clamp(cameraVertical, -90, 90);</strong> impede que a rotação da câmera seja menor que -90 (jogador olhando para o chão) ou maior que 90 (olhando para cima).</li>
<li><strong>Quaternion.Euler(cameraVertical, 0, 0);</strong> transforma os três valores em uma variável para rotação. Seu valor é atribuído a <em>transform.localRotation</em>, rotacionando a câmera verticalmente.</li>
<li><strong>playerTransform.Rotate(Vector3.up * mouseX);</strong> rotaciona o jogador no eixo Y (Vector3.up) de acordo com o movimento horizontal do mouse. Como a câmera está contida nele, ela é rotacionada também.</li>
</ul>
</li>
</ul>
<ol start="3">
<li>Script com Raycast (movimentação de objeto com a câmera)<br>
GravityGun.cs<br>
(imagem)</li>
</ol>
<ul>
<li>
<p>Atributos</p>
<ul>
<li><strong>looking;</strong> <em>Transform</em> de um objeto que é filho do objeto jogador, seguindo sua posição e rotação.</li>
<li><strong>interactions;</strong> referência à <em>LayerMask</em>, ou camada dos objetos que podem ser movidos.</li>
<li><strong>ray;</strong> variável do tipo <em>RaycastHit</em>, recebe e armazena informações do objeto acertado pelo Raycast.</li>
<li><strong>ray.transform.position;</strong> define a posição do objeto acertado pelo Raycast como a posição do objeto vazio à frente da câmera (<strong>looking.transform.position</strong>).</li>
</ul>
</li>
<li>
<p>Métodos</p>
</li>
<li>
<p><strong>LayerMask.GetMask(“Movable”)</strong> busca por uma camada com o nome “Movable” e coloca uma referência à ela na variável <strong>interactions</strong>.</p>
<ul>
<li><strong>Physics.Raycast(transform.position, transform.forward, out RaycastHit ray, 30f, interactions)</strong> cria um raio (linha reta), partindo da posição da câmera (<em>transform.position</em>); indo para onde o jogador/câmera estão olhando (<em>transform.forward</em>); com um tamanho/alcance de 30; onde as informações do objeto colidido ficarão na variável <em>ray</em> e apenas colidirá com objetos da camada <em>interactions</em>.</li>
<li><strong>Input.GetMouseButton(0)</strong> retorna <em>true</em> se o botão esquerdo do mouse (representado pelo “0”) for pressionado. Ao clicar com o mouse, se o Raycast detectar um objeto, a condicional será verdadeira.</li>
</ul>
</li>
</ul>
<ol start="4">
<li>Alterações na cena para o Raycast</li>
</ol>
<ul>
<li>Adição de cubos com rigidbody para o jogador movimentar;</li>
<li>Criação de um material para dar deastaque aos cubos;</li>
<li>Criação de um material para deixar o chão menos escuro;<br>
(imagem)</li>
<li>Camada nova para os objetos que vão interagir com o Raycast.<br>
(imagem)</li>
<li>Objeto vazio cuja posição será a do objeto que for segurado pelo jogador<br>
(imagem)</li>
</ul>
<ol start="6">
<li>Implementação de Prefabs</li>
<li>Vídeo da gameplay</li>
<li>Relatório da dupla</li>
</ol>

